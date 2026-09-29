using eShop_coreBusiness.models;
using eShop_coreBusiness.services;
using eshop_UseCases.PluginInterfaces;
using System;

namespace eshop_UseCases.AdminPortalScreen
{
    public class ProcessOrderUseCase : IProcessOrderUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderService orderService;

        public ProcessOrderUseCase(IOrderRepository orderRepository, IOrderService orderService)
        {
            this.orderRepository = orderRepository;
            this.orderService = orderService;
        }

        public bool Execute(int orderId, string adminUserName)
        {
            var order = orderRepository.GetOrder(orderId);
            if (order == null) return false;

            order.AdminUser = adminUserName;
            order.DateProcessed = DateTime.Now;

            if (!orderService.ValidateProcessOrder(order)) return false;

            orderRepository.UpdateOrder(order);
            return true;
        }
    }
}
