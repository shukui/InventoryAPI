namespace InventoryAPI.Contracts.Article;

public record UpsertArticleRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);