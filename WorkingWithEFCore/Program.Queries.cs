using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, and Product.

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();

        SectionTitle("Categories and how many products they have");

        // A query  to get all categories and their related products.
        // This is a query definition. Nothing has been executed against the database.
        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);
        // You could call any of the following LINQ methods and nothinjg will be executed against the database:
        // Where, GroupBy, Select, SelectMany, OfType, OrderBy, ThenBy, Join, GroupJoin, Take, Skip, Reverse.

        // Usually methods that return IEnumerable or IQueryable support defered execution.

        // Usually methods that return a single value do not support deferred execution.

        if (categories is null || !categories.Any()) // Important order, as Any() would throw an exception if categories is null.
        {
            Fail("No categories found.");
            return;
        }

        // Enumerating the query converts it to SQL and executes it against the database.
        // Execute query andenumerate results.
        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }
}