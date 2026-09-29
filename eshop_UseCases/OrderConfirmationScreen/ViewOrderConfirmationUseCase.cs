using eShop_coreBusiness.models;
using eshop_UseCases.PluginInterfaces;

namespace eshop_UseCases.OrderConfirmationScreen
{
    public class ViewOrderConfirmationUseCase : IViewOrderConfirmationUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrderConfirmationUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order? Execute(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }
    }
}
