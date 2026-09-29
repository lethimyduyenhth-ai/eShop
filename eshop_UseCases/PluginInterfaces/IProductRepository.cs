using eShop_coreBusiness.models;
using System.Collections.Generic;

namespace eshop_UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string filter);
        Product? GetProduct(int id);
    }
}
