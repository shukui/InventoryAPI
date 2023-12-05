namespace InventoryAPI.Contracts.Article;

public record CreateArticleRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);