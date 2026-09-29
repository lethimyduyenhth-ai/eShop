using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public DeleteProductUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public async Task<Order> Execute(int productId)
        {
            return await shoppingCart.DeleteProductAsync(productId);
        }
    }
}
