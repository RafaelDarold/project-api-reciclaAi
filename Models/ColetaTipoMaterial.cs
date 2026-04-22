using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("ColetaTipoMaterial")]
    public class ColetaTipoMaterial
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("quantidade")]
        public decimal Quantidade { get; set; }

        [Column("coleta_id")]
        public int ColetaId { get; set; }

        [ForeignKey(nameof(ColetaId))]
        public virtual Coleta? Coleta { get; set; }

        [Column("tipo_material_id")]
        public int TipoMaterialId { get; set; }

        [ForeignKey(nameof(TipoMaterialId))]
        public virtual TipoMaterial? TipoMaterial { get; set; }
    }
}