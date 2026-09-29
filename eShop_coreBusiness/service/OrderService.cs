using eShop_coreBusiness.models;
using System;
using System.Linq;

namespace eShop_coreBusiness.services
{
    public class OrderService : IOrderService
    {
        // 1. Kiểm tra thông tin khách hàng (Validate Customer Information)
        public bool ValidateCustomerInformation(string name, string address, string city, string province)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (string.IsNullOrWhiteSpace(address)) return false;
            if (string.IsNullOrWhiteSpace(city)) return false;
            if (string.IsNullOrWhiteSpace(province)) return false;

            return true;
        }

        // 2. Kiểm tra khi tạo đơn hàng (Validate Create Order)
        public bool ValidateCreateOrder(Order order)
        {
            if (order == null) return false;

            if (order.LineItems == null || order.LineItems.Count == 0) return false;

            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 || item.Price < 0 || item.Quantity <= 0)
                    return false;
            }

            if (!ValidateCustomerInformation(order.CustomerName, order.CustomerAddress, order.CustomerCity, order.CustomerStateProvince))
                return false;

            return true;
        }

        // 3. Kiểm tra khi cập nhật đơn hàng (Validate Update Order)
        public bool ValidateUpdateOrder(Order order)
        {
            if (order == null) return false;
            if (!order.IdOrder.HasValue || order.IdOrder.Value <= 0) return false;
            if (!order.DatePlaced.HasValue) return false;
            if (order.LineItems == null || order.LineItems.Count == 0) return false;

            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 || item.Price < 0 || item.Quantity <= 0)
                    return false;
            }

            if (!ValidateCustomerInformation(order.CustomerName, order.CustomerAddress, order.CustomerCity, order.CustomerStateProvince))
                return false;

            return true;
        }

        // 4. Kiểm tra khi xử lý đơn hàng (Validate Process Order)
        public bool ValidateProcessOrder(Order order)
        {
            if (order == null) return false;
            if (!order.DateProcessed.HasValue) return false;
            if (string.IsNullOrWhiteSpace(order.AdminUser)) return false;

            return true;
        }
        public bool ValidateProcess(Order order)
        {
            if(!order.DateProcessed.HasValue|| string.IsNullOrWhiteSpace(order.AdminUser) ) return false;
            return true;
        }
    }
}
