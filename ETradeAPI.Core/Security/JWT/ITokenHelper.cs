using ETradeAPI.Core.Entities;

namespace ETradeAPI.Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

}