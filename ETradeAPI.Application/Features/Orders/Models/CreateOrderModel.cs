using ETradeAPI.Application.Features.OrderDetails.Models;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Models
{
    public class CreateOrderModel
    {
        public CreateOrderModel()
        {
            OrderDetails = new HashSet<CreateOrderDetailModel>();
        }
        public Guid UserId { get; set; }
        public ICollection<CreateOrderDetailModel> OrderDetails { get; set; }
        public decimal TotalAmount{ get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string FullAddress { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}
