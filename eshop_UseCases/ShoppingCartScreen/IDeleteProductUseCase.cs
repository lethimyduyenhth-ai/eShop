using eShop_coreBusiness.models;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> Execute(int productId);
    }
}
