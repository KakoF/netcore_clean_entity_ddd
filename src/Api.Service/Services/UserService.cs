using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entityList = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(entityList);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate item)
        {
            if (item.Name == "Teste")
                return null;

            var model = _mapper.Map<UserModel>(item);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(Guid id, UserDtoUpdate item)
        {
            var model = _mapper.Map<UserModel>(item);
            var entity = _mapper.Map<UserEntity>(model);
            var Userpassword = await _repository.SelectAsync(id);
            entity.Password = Userpassword.Password;
            var result = await _repository.UpdasteAsync(id, entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}