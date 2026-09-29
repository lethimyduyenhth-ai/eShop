using eShop_coreBusiness.models;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public interface IPlaceOrderUseCase
    {
        Task<string> Execute(Order order);
    }
}
