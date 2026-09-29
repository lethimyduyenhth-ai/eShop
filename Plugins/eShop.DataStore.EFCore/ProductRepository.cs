using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.DataStore.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<eShopContext> contextFactory;

        public ProductRepository(IDbContextFactory<eShopContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public Product? GetProduct(int id)
        {
            using var db = contextFactory.CreateDbContext();
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            using var db = contextFactory.CreateDbContext();
            if (string.IsNullOrWhiteSpace(filter))
                return db.Products.ToList();

            return db.Products.Where(p => p.Name.ToLower().Contains(filter.Trim().ToLower())).ToList();
        }
    }
}
