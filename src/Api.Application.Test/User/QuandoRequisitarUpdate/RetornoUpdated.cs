using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarUpdate
{
    public class RetornoUpdated
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possível Executar O Update")]
        public async Task E_Possível_Invocar_A_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<Guid>(), It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Name = nome,
                    UpdateAt = DateTime.UtcNow,
                }
            );

            _controller = new UsersController(serviceMock.Object);
            var userDtoUpdate = new UserDtoUpdate
            {
                Email = email,
                Name = nome,
            };

            var result = await _controller.Put(Guid.NewGuid(), userDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultvalue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultvalue);
            Assert.Equal(userDtoUpdate.Name, resultvalue.Name);
            Assert.Equal(userDtoUpdate.Email, resultvalue.Email);

        }
    }
}