using eShop_coreBusiness.models;
using System;

namespace eShop_coreBusiness.services
{
    public interface IOrderService
    {
        bool ValidateCustomerInformation(string name, string address, string city, string province);
        bool ValidateCreateOrder(Order order);
        bool ValidateUpdateOrder(Order order);
        bool ValidateProcessOrder(Order order);
    }
}
