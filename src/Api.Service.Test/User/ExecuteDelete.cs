using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecuteDelete : UserTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executou o método Delete")]
        public async Task Executou_Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUser)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdUser);
            Assert.True(result);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var resultFalse = await _service.Delete(Guid.NewGuid());
            Assert.False(resultFalse);
        }
    }
}