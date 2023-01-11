using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Models
{
    public class UpdateProductModel : CreateProductModel
    {
        public string Id { get; set; }
        public bool Status { get; set; }
    }
}
