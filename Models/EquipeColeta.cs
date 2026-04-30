using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Equipe_Coleta")]
    public class EquipeColeta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("empresa_id")]
        public int EmpresaId { get; set; }

        [ForeignKey(nameof(EmpresaId))]
        public virtual Empresa? Empresa { get; set; }

        public virtual ICollection<Catador> Catador { get; set; } = [];

        public virtual ICollection<Solicitacao> Solicitacao { get; set; } = [];
    }
}