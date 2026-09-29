using eShop_coreBusiness.models;
using eShop_coreBusiness.services;
using eshop_UseCases.PluginInterfaces;
using eshop_UseCases.PluginInterfaces.UI;
using System;
using System.Threading.Tasks;

namespace eshop_UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderService orderService;
        private readonly IShoppingCart shoppingCart;

        public PlaceOrderUseCase(
            IOrderRepository orderRepository,
            IOrderService orderService,
            IShoppingCart shoppingCart)
        {
            this.orderRepository = orderRepository;
            this.orderService = orderService;
            this.shoppingCart = shoppingCart;
        }

        public async Task<string> Execute(Order order)
        {
            if (order == null || !orderService.ValidateCreateOrder(order))
            {
                return string.Empty;
            }

            order.DatePlaced = DateTime.Now;
            var orderId = orderRepository.CreateOrder(order);

            await shoppingCart.EmptyAsync();

            return orderId.ToString();
        }
    }
}
