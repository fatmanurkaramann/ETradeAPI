using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.OrderDetails.Models
{
    public class ViewOrderDetailModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public ViewProductModel  Product { get; set; }
        public decimal LineTotal { get; set; }
        public int Quantity { get; set; }

    }
}
