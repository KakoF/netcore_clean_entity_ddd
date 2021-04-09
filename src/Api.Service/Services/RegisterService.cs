using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Register;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public RegisterService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<object> Register(RegisterRequestDto user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                var model = _mapper.Map<UserModel>(user);
                var entity = _mapper.Map<UserEntity>(model);
                var result = await _repository.InsertAsync(entity);
                if (result == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao registar"
                    };
                }

                return _mapper.Map<RegisterResponseDto>(result);

            }

            return null;
        }
    }
}