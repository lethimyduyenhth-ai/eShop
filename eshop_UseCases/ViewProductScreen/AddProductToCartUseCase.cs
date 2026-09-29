using eshop_UseCases.PluginInterfaces;
using eshop_UseCases.PluginInterfaces.UI;
using eshop_UseCases.ViewProductScreen.interfaces;

namespace eshop_UseCases.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase, IAddProductToCart
    {
        private readonly IProductRepository productRepository;
        private readonly IShoppingCart shoppingCart;

        public AddProductToCartUseCase(IProductRepository productRepository, IShoppingCart shoppingCart)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;
        }

        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);
            if (product != null)
            {
                await shoppingCart.AddProductAsync(product);
            }
        }
    }
}
