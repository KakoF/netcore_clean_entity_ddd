using System;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Municipio
{
    public class CepDtoObject
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicioDtoObject Municio { get; set; }
    }
}