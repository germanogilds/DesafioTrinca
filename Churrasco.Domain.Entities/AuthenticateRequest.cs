using System.ComponentModel.DataAnnotations;

namespace Churrasco.Domain.Entities
{
    public class AuthenticateRequest
    {
        [Required]
        public string NomeDeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
