using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Core.Entities;
using ETradeAPI.Core.Security.Dtos;
using ETradeAPI.Core.Security.Hashing;
using ETradeAPI.Core.Wrappers.Results.Abstract;
using ETradeAPI.Core.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
        }
        public async Task<IResult> UserExist(string emailOrUsername)
        {
            var result = await _userRepository.GetSingleAsync(u => u.Email == emailOrUsername ||u.UserName == emailOrUsername);
            if (result != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);

            }
            return new SuccessResult();
        }
        public IResult VerifyPasswordHash(UserForLoginDto userForLoginDto, User user)
        {

            var result = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!result)
            {
                return new ErrorResult(Messages.LoginError);
            }
            return new SuccessResult();
        }

        public IResult CheckUserStatus(bool status)
        {
            if (!status)
            {
                return new ErrorResult(Messages.UserStatusIsInactive);
            }
            return new SuccessResult();
        }
    }
}
