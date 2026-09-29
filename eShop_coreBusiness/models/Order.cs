using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop_coreBusiness.models
{
    public class Order
    {
        public Order() {
        }
        public int? IdOrder { get; set; }
        public DateTime? DatePlaced { get; set; }   
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateProcessing { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public string CustomerStateProvince { get; set; } = string.Empty;
        public string CustomerCountry { get; set; } = string.Empty;
        public string AdminUser { get; set; } = string.Empty;
        public string UniqueId { get; set; } = string.Empty;
        public List<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();

        // Các phương thức xử lý nghiệp vụ cơ bản trong Entity
        public void AddProduct(Product product, int qty, decimal price)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (item != null)
            {
                item.Quantity += qty;
                if (item.Product == null) item.Product = product;
            }
            else
            {
                LineItems.Add(new OrderLineItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = qty,
                    Price = price
                });
            }
        }

        public void AddProduct(int productId, int qty, decimal price)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity += qty;
            }
            else
            {
                LineItems.Add(new OrderLineItem
                {
                    ProductId = productId,
                    Quantity = qty,
                    Price = price
                });
            }
        }

        public void RemoveProduct(int lineItemId)
        {
            var item = LineItems.FirstOrDefault(x => x.LineItemId == lineItemId);
            if (item != null)
            {
                LineItems.Remove(item);
            }
        }

    }
}
