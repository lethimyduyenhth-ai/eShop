using eShop_coreBusiness.models;

namespace eshop_UseCases.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order? Execute(int orderId);
    }
}
