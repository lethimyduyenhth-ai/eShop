using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces;

namespace eshop_UseCases.ViewProductScreen
{
    public class viewProductUseCase : IViewProduct
    {
        private readonly IProductRepository productRepository;

        public viewProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product? Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
