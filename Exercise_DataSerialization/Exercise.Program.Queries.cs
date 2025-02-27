using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, and Product.

partial class Program
{
    private static void GettingAllCategoriesAndProducts()
    {
        using NorthwindDb db = new();

        SectionTitle("All categories and their products");

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);

        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products. These are:");
            foreach (Product p in c.Products)
            {
                WriteLine($"    {p.ProductName}");
            }
        }

    }
}