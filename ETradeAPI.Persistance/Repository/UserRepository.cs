using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.DataAccess;
using ETradeAPI.Core.Entities;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repository
{
    public class UserRepository : EfEntityRepositoryBase<User, ETradeAPIDbContext>, IUserRepository
    {
        public UserRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
