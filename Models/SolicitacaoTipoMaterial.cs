using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Solicitacao_Tipo_Material")]
    public class SolicitacaoTipoMaterial
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("quantidade")]
        public decimal Quantidade { get; set; }

        [Column("solicitacao_id")]
        public int SolicitacaoId { get; set; }

        [ForeignKey(nameof(SolicitacaoId))]
        public virtual Solicitacao? Solicitacao { get; set; }

        [Column("tipo_material_id")]
        public int TipoMaterialId { get; set; }

        [ForeignKey(nameof(TipoMaterialId))]
        public virtual TipoMaterial? TipoMaterial { get; set; }
    }
}