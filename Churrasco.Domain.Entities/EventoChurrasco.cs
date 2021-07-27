using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churrasco.Domain.Entities
{
    [Table("EventoChurrasco")]
    public class EventoChurrasco
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a Data do Churrasco")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Churrasco")]
        public string Nome { get; set; }
        [StringLength(120, ErrorMessage = "O tamanho da observação não pode exceder 120 caracteres")]
        public string Observacao { get; set; }
        [Required(ErrorMessage = "Informe um valor para o churrasco")]
        [Column(TypeName ="decimal(8,2)")]
        public decimal ValorChurrasco { get; set; }
        [Required(ErrorMessage = "Informe um valor para o churrasco com bebida")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal ValorComBebida { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }
        public EventoChurrasco()
        {
            Participantes = new List<Participante>();
        }

    }
}
