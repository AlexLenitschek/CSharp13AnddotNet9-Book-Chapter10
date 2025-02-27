using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels; // To use Northwind.


using NorthwindDb db = new();

SectionTitle("All categories and their products");

IQueryable<Category>? categories = db.Categories?
    .Include(c => c.Products);

if (categories is null || !categories.Any())
{
    Fail("No categories found.");
    return;
}

// Taken for the Solution because I ain't got time for that :D
GenerateXmlFile(categories);
GenerateXmlFile(categories, useAttributes: false);
GenerateCsvFile(categories);
GenerateJsonFile(categories);

WriteLine($"Current directory: {Environment.CurrentDirectory}");

//foreach (Category c in categories)
//{
//    WriteLine($"{c.CategoryName} has {c.Products.Count} products. These are:");
//    foreach (Product p in c.Products)
//    {
//        WriteLine($"    {p.ProductName}");
//    }
//}