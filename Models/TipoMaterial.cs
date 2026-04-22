using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("TipoMaterial")]
    public class TipoMaterial
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("tipo_peso")]
        public required string TipoPeso { get; set; }

        [Column("criadoEm")]
        public DateTime CriadoEm { get; set; }

        [Column("atualizadoEm")]
        public DateTime AtualizadoEm { get; set; }

        public virtual ICollection<SolicitacaoTipoMaterial> SolicitacoesMaterial { get; set; } = [];

        public virtual ICollection<ColetaTipoMaterial> ColetasMaterial { get; set; } = [];
    }
}