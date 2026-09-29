using eShop_coreBusiness.models;
using System.Collections.Generic;

namespace eshop_UseCases.AdminPortalScreen
{
    public interface IViewOutstandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}
