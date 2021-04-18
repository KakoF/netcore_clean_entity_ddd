using System;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoList
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
    }
}