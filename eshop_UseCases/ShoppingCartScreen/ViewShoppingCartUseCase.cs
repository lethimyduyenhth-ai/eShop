using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public async Task<Order> Execute()
        {
            return await shoppingCart.GetOrderAsync();
        }
    }
}
