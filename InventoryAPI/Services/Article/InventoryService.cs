using InventoryAPI.Models;
using InventoryAPI.ServiceErrors;
using ErrorOr;

namespace InventoryAPI.Services.Inventory;

public class InventoryService : IInventoryService
{
    private static readonly Dictionary<Guid, Article> _articles = new();

    public ErrorOr<Created> CreateArticle(Article article)
    {
        _articles.Add(article.Id, article);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteArticle(Guid id)
    {
        _articles.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<Article> GetArticle(Guid id)
    {
        if (_articles.TryGetValue(id, out var article))
        {
            return article;
        }

        return Errors.Article.NotFound;
    }

    public ErrorOr<UpsertedArticle> UpsertArticle(Article article)
    {
        var isNewlyCreated = !_articles.ContainsKey(article.Id);
        _articles[article.Id] = article;

        return new UpsertedArticle(isNewlyCreated);
    }
}
