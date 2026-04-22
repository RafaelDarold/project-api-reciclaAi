using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Coleta")]
    public class Coleta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("dataColeta")]
        public DateTime DataColeta { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("observacao")]
        public required string Observacao { get; set; }

        [Column("pesoTotal")]
        public decimal PesoTotal { get; set; }

        [Column("horaColeta")]
        public TimeSpan HoraColeta { get; set; }

        [Column("solicitacao_id")]
        public int SolicitacaoId { get; set; }

        [ForeignKey(nameof(SolicitacaoId))]
        public virtual Solicitacao? Solicitacao { get; set; }

        public virtual ICollection<ColetaTipoMaterial> ColetaTipoMaterials { get; set; } = [];
    }
}