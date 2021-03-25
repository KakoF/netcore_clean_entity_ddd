using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecutePut : UserTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executou o método Put")]
        public async Task Executou_Put()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(IdUser, userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(IdUser, userDtoUpdate);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUser);
            Assert.Equal(NameUser, result.Name);
            Assert.Equal(EmailUser, result.Email);

        }
    }
}