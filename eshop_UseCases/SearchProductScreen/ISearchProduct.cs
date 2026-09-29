using eShop_coreBusiness.models;
using System.Collections.Generic;

namespace eshop_UseCases.SearchProductScreen
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string filter = "");
    }
}
