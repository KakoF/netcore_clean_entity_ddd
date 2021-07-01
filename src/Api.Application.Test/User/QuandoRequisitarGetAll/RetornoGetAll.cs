using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarGetAll
{
    public class RetornoGet
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possível Executar O GetAll")]
        public async Task E_Possível_Invocar_A_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                   new UserDto{
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                   },
                   new UserDto{
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                   },
                   new UserDto{
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                   }
                }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultvalue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.NotNull(resultvalue);
            Assert.True(resultvalue.Count() > 0);

        }
    }
}