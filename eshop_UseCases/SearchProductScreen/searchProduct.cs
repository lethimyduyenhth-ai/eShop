using System.Collections.Generic;
using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces;

namespace eshop_UseCases.SearchProductScreen
{
    public class searchProduct : ISearchProduct
    {
        private readonly IProductRepository productRepository;

        public searchProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter = "")
        {
            return productRepository.GetProducts(filter);
        }
    }
}
