using Northwind.EntityModels; // To use Northwind.

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");
// The use of using ensures that the database context gets disposed after use.