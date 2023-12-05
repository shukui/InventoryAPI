using InventoryAPI.Contracts.Article;
using InventoryAPI.Models;
using InventoryAPI.ServiceErrors;
using InventoryAPI.Services.Inventory;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers;

public class InventoryController : ApiController
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService breakfastService)
    {
        _inventoryService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateArticle(CreateArticleRequest request)
    {
        ErrorOr<Article> requestToInventoryResult = Article.From(request);

        if (requestToInventoryResult.IsError)
        {
            return Problem(requestToInventoryResult.Errors);
        }

        var breakfast = requestToInventoryResult.Value;
        ErrorOr<Created> createInventoryResult = _inventoryService.CreateArticle(breakfast);

        return createInventoryResult.Match(
            created => CreatedAtGetInventory(breakfast),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetArticle(Guid id)
    {
        ErrorOr<Article> getBreakfastResult = _inventoryService.GetArticle(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapInventoryResponse(breakfast)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertInventory(Guid id, UpsertArticleRequest request)
    {
        ErrorOr<Article> requestToArticleResult = Article.From(id, request);

        if (requestToArticleResult.IsError)
        {
            return Problem(requestToArticleResult.Errors);
        }

        var article = requestToArticleResult.Value;
        ErrorOr<UpsertedArticle> upsertArticleResult = _inventoryService.UpsertArticle(article);

        return upsertArticleResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetInventory(article) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteInventory(Guid id)
    {
        ErrorOr<Deleted> deleteBreakfastResult = _inventoryService.DeleteArticle(id);

        return deleteBreakfastResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static ArticleResponse MapInventoryResponse(Article article)
    {
        return new ArticleResponse(
            article.Id,
            article.Name,
            article.Description,
            article.StartDateTime,
            article.EndDateTime,
            article.LastModifiedDateTime,
            article.Savory,
            article.Sweet);
    }

    private CreatedAtActionResult CreatedAtGetInventory(Article article)
    {
        return CreatedAtAction(
            actionName: nameof(GetArticle),
            routeValues: new { id = article.Id },
            value: MapInventoryResponse(article));
    }
}