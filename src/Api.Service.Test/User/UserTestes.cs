using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTestes
    {

        public UserTestes()
        {
            IdUser = Guid.NewGuid();
            EmailUser = Faker.Internet.Email();
            AlterEmailUser = Faker.Internet.Email();
            NameUser = Faker.Name.FullName();
            AlterNameUser = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto()
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser
            };

            userDtoCreate = new UserDtoCreate()
            {
                Name = NameUser,
                Email = EmailUser
            };


            userDtoCreateResult = new UserDtoCreateResult()
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate()
            {
                Name = NameUser,
                Email = EmailUser
            };

            userDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                UpdateAt = DateTime.UtcNow
            };

        }
        public static string NameUser { get; set; }
        public static string EmailUser { get; set; }
        public static string AlterNameUser { get; set; }
        public static string AlterEmailUser { get; set; }
        public static Guid IdUser { get; set; }

        public UserDto userDto;
        public List<UserDto> listUserDto = new List<UserDto>();
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;
    }
}