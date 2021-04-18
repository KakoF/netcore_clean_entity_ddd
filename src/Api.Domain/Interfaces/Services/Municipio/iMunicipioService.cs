using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface iMunicipioService
    {
        Task<MunicioDtoObject> Get(Guid id);
        Task<MunicioDtoObject> GetByIBGE(int IBGE);
        Task<IEnumerable<MunicipioDtoList>> GetAll();
        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);
        Task<MunicipioDtoUpdateResult> Put(Guid id, MunicipioDtoUpdate municipio);
        Task<bool> Delete(Guid id);

    }
}