using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.HardCode
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();

            var order1 = new Order
            {
                IdOrder = 1,
                CustomerName = "Nguyễn Văn A",
                CustomerAddress = "123 Đường Lê Lợi",
                CustomerCity = "Hồ Chí Minh",
                CustomerStateProvince = "Quận 1",
                CustomerCountry = "Việt Nam",
                DatePlaced = DateTime.Now.AddHours(-3),
                LineItems = new List<OrderLineItem>
                {
                    new OrderLineItem { LineItemId = 1, ProductId = 286, Quantity = 1, Price = 17.99m, OrderId = 1, Product = new Product { Id = 286, Name = "Maybelline The Nudes Eyeshadow Palette in The Blushed Nudes", Price = 17.99m } },
                    new OrderLineItem { LineItemId = 2, ProductId = 320, Quantity = 2, Price = 10.99m, OrderId = 1, Product = new Product { Id = 320, Name = "Maybelline FIT ME! Matte + Poreless Foundation", Price = 10.99m } }
                }
            };

            var order2 = new Order
            {
                IdOrder = 2,
                CustomerName = "Trần Thị B",
                CustomerAddress = "456 Đường Trần Hưng Đạo",
                CustomerCity = "Hà Nội",
                CustomerStateProvince = "Quận Hoàn Kiếm",
                CustomerCountry = "Việt Nam",
                DatePlaced = DateTime.Now.AddDays(-1),
                LineItems = new List<OrderLineItem>
                {
                    new OrderLineItem { LineItemId = 3, ProductId = 477, Quantity = 1, Price = 15.99m, OrderId = 2, Product = new Product { Id = 477, Name = "Maybelline Facestudio Master Contour Kit", Price = 15.99m } }
                }
            };

            orders.Add(order1.IdOrder.Value, order1);
            orders.Add(order2.IdOrder.Value, order2);
        }

        public int CreateOrder(Order order)
        {
            order.IdOrder = orders.Count + 1;
            order.DatePlaced = DateTime.Now;
            orders.Add(order.IdOrder.Value, order);
            return order.IdOrder.Value;
        }

        public Order? GetOrder(int id)
        {
            if (orders.TryGetValue(id, out var order))
            {
                return order;
            }
            return null;
        }

        public void UpdateOrder(Order order)
        {
            if (order.IdOrder.HasValue && orders.ContainsKey(order.IdOrder.Value))
            {
                orders[order.IdOrder.Value] = order;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            return orders.Values.Where(x => !x.DateProcessed.HasValue);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            return orders.Values.Where(x => x.DateProcessed.HasValue);
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var order = GetOrder(orderId);
            if (order != null)
            {
                return order.LineItems;
            }
            return new List<OrderLineItem>();
        }
    }
}
