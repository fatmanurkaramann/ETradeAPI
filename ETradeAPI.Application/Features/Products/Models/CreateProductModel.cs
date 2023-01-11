using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Stock { get; set; }
        public string ProductImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
