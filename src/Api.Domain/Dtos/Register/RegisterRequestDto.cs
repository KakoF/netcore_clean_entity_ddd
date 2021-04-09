using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Register
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "E-mail é campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório.")]
        [MinLength(3, ErrorMessage = "E-mail deve ter no minímo {3} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Senha é campo obrigatório.")]
        public string Password { get; set; }
    }
}