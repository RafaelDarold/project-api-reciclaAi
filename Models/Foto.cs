using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Foto")]
    public class Foto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("url")]
        public required string Url { get; set; }

        [Column("solicitacao_id")]
        public int SolicitacaoId { get; set; }

        [ForeignKey(nameof(SolicitacaoId))]
        public virtual Solicitacao? Solicitacao { get; set; }
    }
}