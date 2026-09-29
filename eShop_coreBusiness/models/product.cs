using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_coreBusiness.models
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public string ImageLink { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}