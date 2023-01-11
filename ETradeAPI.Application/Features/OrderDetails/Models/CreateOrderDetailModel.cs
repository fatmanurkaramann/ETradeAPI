using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.OrderDetails.Models
{
    public class CreateOrderDetailModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal{ get; set; }
    }
}
