using ETradeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Core.Entities
{
    public class OperationClaim : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
