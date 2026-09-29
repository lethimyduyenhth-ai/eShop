using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.DataStore.EFCore
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory<eShopContext> contextFactory;

        public OrderRepository(IDbContextFactory<eShopContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public int CreateOrder(Order order)
        {
            using var db = contextFactory.CreateDbContext();
            order.DatePlaced = DateTime.Now;
            if (string.IsNullOrWhiteSpace(order.UniqueId))
            {
                order.UniqueId = Guid.NewGuid().ToString();
            }

            if (order.IdOrder.HasValue && order.IdOrder.Value <= 0)
            {
                order.IdOrder = null;
            }

            if (order.LineItems != null)
            {
                foreach (var item in order.LineItems)
                {
                    if (item.LineItemId.HasValue && item.LineItemId.Value <= 0)
                    {
                        item.LineItemId = null;
                    }
                    item.Product = null;
                }
            }

            db.Orders.Add(order);
            db.SaveChanges();
            return order.IdOrder ?? 0;
        }

        public Order? GetOrder(int id)
        {
            using var db = contextFactory.CreateDbContext();
            return db.Orders
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.IdOrder == id);
        }

        public void UpdateOrder(Order order)
        {
            using var db = contextFactory.CreateDbContext();
            if (order.LineItems != null)
            {
                foreach (var item in order.LineItems)
                {
                    item.Product = null;
                }
            }
            db.Orders.Update(order);
            db.SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            using var db = contextFactory.CreateDbContext();
            return db.Orders
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                .ToList();
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            using var db = contextFactory.CreateDbContext();
            return db.Orders
                .Where(x => !x.DateProcessed.HasValue)
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                .ToList();
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            using var db = contextFactory.CreateDbContext();
            return db.Orders
                .Where(x => x.DateProcessed.HasValue)
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                .ToList();
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            using var db = contextFactory.CreateDbContext();
            var order = db.Orders
                .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.IdOrder == orderId);

            return order?.LineItems ?? new List<OrderLineItem>();
        }
    }
}
