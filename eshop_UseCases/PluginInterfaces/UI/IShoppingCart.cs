using eShop_coreBusiness.models;
using System;
using System.Threading.Tasks;

namespace eshop_UseCases.PluginInterfaces.UI
{
    public interface IShoppingCart
    {
        event Action? OnChange;

        Task<Order> GetOrderAsync();
        Task<Order> AddProductAsync(Product product);
        Task<Order> UpdateQuantityAsync(int productId, int quantity);
        Task<Order> DeleteProductAsync(int productId);
        Task EmptyAsync();
        Task<Order> UpdateOrderAsync(Order order);
    }
}
