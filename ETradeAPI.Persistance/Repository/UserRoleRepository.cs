using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.DataAccess;
using ETradeAPI.Core.Entities;
using ETradeAPI.Persistance.Contexts;


namespace ETradeAPI.Persistance.Repository
{
    public class UserOperationClaimRepository : EfEntityRepositoryBase<UserOperationClaim, ETradeAPIDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
