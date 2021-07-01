using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoOLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar O Login")]
        public async Task E_Possível_Executar_O_Login()
        {
            var email = Faker.Internet.Email();
            var senha = Guid.NewGuid();
            var objetoRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = Faker.Name.FullName(),
                message = "Usuário logado com sucesso.",
            };

            var loginDto = new LoginDto
            {
                Email = email,
                Password = senha.ToString(),
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.Login(loginDto)).ReturnsAsync(objetoRetorno);
            _service = _serviceMock.Object;
            var result = await _service.Login(loginDto);

            Assert.NotNull(result);
        }
    }
}