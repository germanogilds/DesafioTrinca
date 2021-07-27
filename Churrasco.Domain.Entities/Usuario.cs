using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churrasco.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Login")]
        public string NomeDeUsuario { get; set; }
        [Required(ErrorMessage = "Informe s Senha)")]
        public string Senha { get; set; }
        public bool ativo { get; set; }

    }
}
