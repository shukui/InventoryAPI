using InventoryAPI.Models;
using ErrorOr;

namespace InventoryAPI.Services.Inventory;

public interface IInventoryService
{
    ErrorOr<Created> CreateArticle(Article article);
    ErrorOr<Article> GetArticle(Guid id);
    ErrorOr<UpsertedArticle> UpsertArticle(Article article);
    ErrorOr<Deleted> DeleteArticle(Guid id);
}