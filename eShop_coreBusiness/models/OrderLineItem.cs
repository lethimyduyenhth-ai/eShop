using eShop_coreBusiness.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_coreBusiness.models
{
    public class OrderLineItem
    {
        public int? LineItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Product? Product { get; set; }
    }
}
