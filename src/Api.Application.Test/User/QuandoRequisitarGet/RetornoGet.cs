using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarGet
{
    public class RetornoGet
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possível Executar O Get")]
        public async Task E_Possível_Invocar_A_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Name = nome,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultvalue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultvalue);
            Assert.Equal(resultvalue.Name, resultvalue.Name);
            Assert.Equal(resultvalue.Email, resultvalue.Email);

        }
    }
}