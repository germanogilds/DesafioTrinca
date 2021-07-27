using System.ComponentModel.DataAnnotations;
using Churrasco.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Churrasco.Domain.Entities
{
    [Table("Participante")]
    public class Participante
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Participante")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Tipo de Participação (1 - Com Bebida / 2 - Sem Bebida)")]
        public ValorChurrascoEnum TipoDeParticipacao { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? ValorPago { get; set; }

        public int ChurrascoId { get; set; }
        [JsonIgnore]
        public virtual EventoChurrasco Churrasco { get; set; }


        #region Validação do Participante

        public string ExisteChurrascoParaParticipante(EventoChurrasco obj)
        {
            
            if (obj == null)
            {
                return "Churrasco não encontrado";
            }
            return string.Empty;

        }
        public string VerificaValorPago(Participante participante,EventoChurrasco eventoChurrasco)
        {
            
            if (participante.ValorPago != null &&
                          (participante.TipoDeParticipacao == Entities.Enums.ValorChurrascoEnum.SemBebida && participante.ValorPago != eventoChurrasco.ValorChurrasco) ||
                          (participante.TipoDeParticipacao == Entities.Enums.ValorChurrascoEnum.ComBebida && participante.ValorPago != eventoChurrasco.ValorComBebida))
            {
                return $"Valor diferente do sugerido, Sem bebida:{eventoChurrasco.ValorChurrasco} e Com bebida:{eventoChurrasco.ValorComBebida}";
            }
            return string.Empty;

        }
        #endregion
    }
}
