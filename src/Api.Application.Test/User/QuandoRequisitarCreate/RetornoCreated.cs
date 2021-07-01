using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarCreate
{
    public class RetornoCreated
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possível Executar O Create")]
        public async Task E_Possível_Invocar_A_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var password = Guid.NewGuid();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Name = nome,
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new UsersController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;
            var userDtoCreate = new UserDtoCreate
            {
                Email = email,
                Name = nome,
                Password = password.ToString()
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is CreatedResult);

            var resultvalue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultvalue);
            Assert.Equal(userDtoCreate.Name, resultvalue.Name);
            Assert.Equal(userDtoCreate.Email, resultvalue.Email);

        }
    }
}