using ETradeAPI.Core.Entities;
using ETradeAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public decimal TotalAmount { get; set; }
        public string FullAddress { get; set; }
        public DateTime ShipmentDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
