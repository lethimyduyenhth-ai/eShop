using eShop_coreBusiness.models;

namespace eshop_UseCases.ViewProductScreen
{
    public interface IViewProduct
    {
        Product? Execute(int id);
    }
}
