using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.DataAccess;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repository
{
    public class OrderRepository : EfEntityRepositoryBase<Order, ETradeAPIDbContext>, IOrderRepository
    {
        public OrderRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
