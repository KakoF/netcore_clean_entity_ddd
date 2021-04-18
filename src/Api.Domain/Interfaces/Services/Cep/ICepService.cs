using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDtoObject> Get(Guid id);
        Task<CepDtoObject> Get(string cep);
        Task<CepDtoCreateResult> Post(CepDtoCreate cep);
        Task<CepDtoUpdateResult> Put(Guid id, CepDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}