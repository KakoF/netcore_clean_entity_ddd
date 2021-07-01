using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarDelete
{
    public class RetornoDelete
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possível Executar O Delete")]
        public async Task E_Possível_Invocar_A_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultvalue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultvalue);
            Assert.True((Boolean)resultvalue);

        }
    }
}