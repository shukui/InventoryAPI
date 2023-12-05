using ErrorOr;

namespace InventoryAPI.ServiceErrors;

public static class Errors
{
    public static class Article
    {
        public static Error InvalidName => Error.Validation(
            code: "Inventory.InvalidName",
            description: $"Inventory name must be at least {Models.Article.MinNameLength}" +
                $" characters long and at most {Models.Article.MaxNameLength} characters long.");

        public static Error InvalidDescription => Error.Validation(
            code: "Inventory.InvalidDescription",
            description: $"Inventory description must be at least {Models.Article.MinDescriptionLength}" +
                $" characters long and at most {Models.Article.MaxDescriptionLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Inventory.NotFound",
            description: "Inventory not found");
    }
}