using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRangeAsync(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var productTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                context.ProductTypes.AddRangeAsync(productTypes);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRangeAsync(products);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}