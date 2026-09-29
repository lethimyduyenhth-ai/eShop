using eShop_coreBusiness.models;
using System.Collections.Generic;

namespace eshop_UseCases.PluginInterfaces
{
    public interface IOrderRepository
    {
        int CreateOrder(Order order);
        Order? GetOrder(int id);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOutstandingOrders();
        IEnumerable<Order> GetProcessedOrders();
        IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId);
    }
}
