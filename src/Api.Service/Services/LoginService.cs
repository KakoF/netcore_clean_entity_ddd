using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly SigninConfigurations _signinConfigurations;

        private IConfiguration _configuration { get; }
        public LoginService(IUserRepository repository, IMapper mapper, TokenConfiguration tokenConfiguration, SigninConfigurations signinConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _tokenConfiguration = tokenConfiguration;
            _signinConfigurations = signinConfigurations;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<object> Login(LoginDto user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.Login(user.Email, user.Password);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }

                var userLogin = _mapper.Map<LoginResponseDto>(baseUser);

                var identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email),
                    new[]{
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userLogin.Name),
                        new Claim(JwtRegisteredClaimNames.Email, userLogin.Email),
                    }
                );
                DateTime createdDate = DateTime.Now;
                DateTime expirationDate = createdDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var token = CreateToken(identity, createdDate, expirationDate, handler);
                return SuccessObject(createdDate, expirationDate, token, userLogin);


            }

            return null;
        }


        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createdDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
        private object SuccessObject(DateTime createdDate, DateTime expirationDate, string token, LoginResponseDto user)
        {
            return new
            {
                authenticated = true,
                created = createdDate,
                expiration = expirationDate,
                accessToken = token,
                userName = user.Name,
                message = "Usuário logado com sucesso.",
            };
        }
    }
}