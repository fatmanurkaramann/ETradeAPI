using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Enums
{
    public enum OrderStatus
    {
        Taken,
        Preparing,
        OnWay,
        Delivered,
        Canceled
    }
}
