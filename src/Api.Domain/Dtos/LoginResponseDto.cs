using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


    }
}