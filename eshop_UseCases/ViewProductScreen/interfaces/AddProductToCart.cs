using eshop_UseCases.PluginInterfaces;
using eshop_UseCases.PluginInterfaces.UI;

namespace eshop_UseCases.ViewProductScreen.interfaces
{
    public class AddProductToCart : AddProductToCartUseCase
    {
        public AddProductToCart(IProductRepository productRepository, IShoppingCart shoppingCart) 
            : base(productRepository, shoppingCart)
        {
        }
    }
}
