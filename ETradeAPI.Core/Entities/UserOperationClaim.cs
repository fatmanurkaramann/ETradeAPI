using ETradeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Core.Entities
{
    public class UserOperationClaim : BaseEntity
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
        public Guid RoleId { get; set; }
    }
}
