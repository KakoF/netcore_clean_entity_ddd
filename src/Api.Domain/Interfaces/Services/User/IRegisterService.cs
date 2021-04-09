using System.Threading.Tasks;
using Api.Domain.Dtos.Register;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IRegisterService
    {
        Task<object> Register(RegisterRequestDto user);
    }
}