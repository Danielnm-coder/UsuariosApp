using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.Services.Models
{
    /// <summary>
    /// Modelo de dados da requisição de autenticação de usuários.
    /// </summary>
    public class AutenticarRequestModel
    {
        [EmailAddress(ErrorMessage = "Por favor , informe um endereço de email valido.")]
        [Required(ErrorMessage = "Por favor , informe o email do usuario.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso do usuário.")]
        public string? Senha { get; set; }
    }
}
