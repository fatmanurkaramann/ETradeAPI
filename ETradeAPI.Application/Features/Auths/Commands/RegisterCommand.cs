using AutoMapper;
using ETradeAPI.Application.Features.Auths.Dtos;
using ETradeAPI.Application.RepositoryInterfaces;
using ETradeAPI.Application.Services.AuthService;
using ETradeAPI.Core.Entities;
using ETradeAPI.Core.Security.Dtos;
using ETradeAPI.Core.Security.Hashing;
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
    public class RegisterCommand : IRequest<IDataResult<RegisteredDto>>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IDataResult<RegisteredDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;
            public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, IMapper mapper)
            {
                _userRepository = userRepository;
                _authService = authService;
                _mapper = mapper;
            }

            public async Task<IDataResult<RegisteredDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    UserName = request.UserForRegisterDto.UserName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    FullAddress = request.UserForRegisterDto.FullAddress
                };

                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                return new SuccessDataResult<RegisteredDto>(new RegisteredDto { AccessToken = createdAccessToken , User = createdUser }, Messages.RegisteredSuccessfully);

            }
        }
    }
}
