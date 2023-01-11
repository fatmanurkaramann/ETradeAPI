using ETradeAPI.Core.Entities;
using ETradeAPI.Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Auths.Dtos
{
    public class RegisteredDto
    {
        public AccessToken AccessToken { get; set; }
        public User User { get; set; }
    }
}
