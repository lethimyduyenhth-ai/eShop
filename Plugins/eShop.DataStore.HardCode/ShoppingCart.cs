using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces.UI;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.DataStore.HardCode
{
    public class ShoppingCart : IShoppingCart
    {
        private Order order;

        public event Action? OnChange;

        public ShoppingCart()
        {
            order = new Order();
        }

        public Task<Order> GetOrderAsync()
        {
            return Task.FromResult(order);
        }

        public Task<Order> AddProductAsync(Product product)
        {
            if (order == null)
            {
                order = new Order();
            }

            order.AddProduct(product, 1, product.Price);
            OnChange?.Invoke();

            return Task.FromResult(order);
        }

        public Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var item = order.LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    order.LineItems.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
                OnChange?.Invoke();
            }

            return Task.FromResult(order);
        }

        public Task<Order> DeleteProductAsync(int productId)
        {
            var item = order.LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                order.LineItems.Remove(item);
                OnChange?.Invoke();
            }

            return Task.FromResult(order);
        }

        public Task EmptyAsync()
        {
            order = new Order();
            OnChange?.Invoke();
            return Task.CompletedTask;
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            this.order = order;
            OnChange?.Invoke();
            return Task.FromResult(this.order);
        }
    }
}
