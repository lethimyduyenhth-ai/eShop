using eShop_coreBusiness.models;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}
