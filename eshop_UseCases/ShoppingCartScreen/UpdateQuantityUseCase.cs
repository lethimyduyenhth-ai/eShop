using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public UpdateQuantityUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public async Task<Order> Execute(int productId, int quantity)
        {
            return await shoppingCart.UpdateQuantityAsync(productId, quantity);
        }
    }
}
