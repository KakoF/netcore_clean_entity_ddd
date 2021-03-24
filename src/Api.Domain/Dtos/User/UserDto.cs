using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Name é campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Name deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail é campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}