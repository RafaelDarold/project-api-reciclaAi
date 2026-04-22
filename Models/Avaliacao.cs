using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("satisfacaoColeta")]
        public int SatisfacaoColeta { get; set; }

        [Column("observacao")]
        public string? Observacao { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente? Cliente { get; set; }

        [Column("coleta_id")]
        public int ColetaId { get; set; }

        [ForeignKey(nameof(ColetaId))]
        public virtual Coleta? Coleta { get; set; }
    }
}
