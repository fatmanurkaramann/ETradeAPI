using ETradeAPI.Core.Wrappers.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Orders.Models
{
    public class OrderListModel : BasePageableModel
    {
        public IList<ViewOrderModel> Items { get; set; }
    }
}
