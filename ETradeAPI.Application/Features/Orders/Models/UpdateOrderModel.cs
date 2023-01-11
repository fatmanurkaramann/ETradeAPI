using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Models
{
    public class UpdateOrderModel : CreateOrderModel
    {
        public string Id { get; set; }
        public bool Status { get; set; }
    }
}
