using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class QuandoForExecutadoGet : UserTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executou o método Get")]
        public async Task Executou_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUser)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUser);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUser);
            Assert.Equal(NameUser, result.Name);
            Assert.Equal(EmailUser, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUser);
            Assert.Null(_record);

        }
    }
}