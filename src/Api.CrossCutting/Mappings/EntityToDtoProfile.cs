using Api.Domain.Dtos;
using Api.Domain.Dtos.Register;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
            CreateMap<RegisterResponseDto, UserEntity>().ReverseMap();
            CreateMap<LoginResponseDto, UserEntity>().ReverseMap();
        }
    }
}