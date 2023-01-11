using ETradeAPI.Application.Features.Auths.Dtos;
using ETradeAPI.Application.Features.Auths.Rules;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Application.Services.AuthService;
using ETradeAPI.Core.BusinessRules;
using ETradeAPI.Core.Entities;
using ETradeAPI.Core.Security.Dtos;
using ETradeAPI.Core.Security.JWT;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Auths.Commands
{
    public class LoginCommand : IRequest<IDataResult<LoginDto>>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, IDataResult<LoginDto>>
        {
            private readonly IUserRepository _UserRepository;
            private readonly AuthBusinessRules _authorizationBusinessRules;
            private readonly IAuthService _authService;
            public LoginCommandHandler(IUserRepository UserRepository, AuthBusinessRules authorizationBusinessRules, IAuthService authService)
            {
                _UserRepository = UserRepository;
                _authorizationBusinessRules = authorizationBusinessRules ?? throw new ArgumentNullException(nameof(authorizationBusinessRules));
                _authService = authService;
            }

            public async Task<IDataResult<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var userToCheck = await _UserRepository.GetSingleAsync(u => u.Email == request.UserForLoginDto.EmailOrUsername
                                                                        || 
                                                                       u.UserName == request.UserForLoginDto.EmailOrUsername);
                if (userToCheck == null)
                {
                    return new ErrorDataResult<LoginDto>(Messages.LoginError);
                }
                IResult result = BusinessRules.Run(
                    _authorizationBusinessRules.VerifyPasswordHash(request.UserForLoginDto, userToCheck),
                    _authorizationBusinessRules.CheckUserStatus(userToCheck.Status)
                    );
                if (result != null)
                {
                    return new ErrorDataResult<LoginDto>(result.Message);
                }
                var token = await _authService.CreateAccessToken(userToCheck);
                LoginDto loginDto = new() { AccessToken = token, User = userToCheck};
                if (loginDto.User.UserName.Equals("superadmin"))
                {
                    userToCheck.Roles = new UserOperationClaim[] { new UserOperationClaim { OperationClaim = new OperationClaim { Name = "SuperAdmin" } } };
                }
                return new SuccessDataResult<LoginDto>(loginDto, Messages.SuccessfulLogin);
            }
        }
    }
}
