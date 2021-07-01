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
    public class RetornoBadRequest
    {
        private UsersController _controller;
        [Fact(DisplayName = "Não Foi Possivel Realizar O Update")]
        public async Task Erro_Ao_Invocar_A_Controller_Update()
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
            _controller.ModelState.AddModelError("Email", "Email é um campo obrigatório");
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            _controller.Url = url.Object;
            var userDtoUpdate = new UserDtoUpdate
            {
                Email = email,
                Name = nome,
            };

            var result = await _controller.Put(Guid.NewGuid(), userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}