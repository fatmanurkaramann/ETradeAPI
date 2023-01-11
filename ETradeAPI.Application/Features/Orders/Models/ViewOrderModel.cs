using ETradeAPI.Application.Features.OrderDetails.Models;
using ETradeAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Models
{
    public class ViewOrderModel
    {
        public ViewOrderModel()
        {
            OrderDetails = new HashSet<ViewOrderDetailModel>();
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<ViewOrderDetailModel> OrderDetails { get; set; }
        public decimal TotalAmount{ get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string FullAddress { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}
