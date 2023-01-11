using ETradeAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

            Roles = new HashSet<UserOperationClaim>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string FullAddress { get; set; }
        public ICollection<UserOperationClaim>? Roles { get; set; }
    }
}
