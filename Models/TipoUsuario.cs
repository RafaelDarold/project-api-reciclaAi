using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Tipo_Usuario")]
    public class TipoUsuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("nivel_acesso")]
        public int NivelAcesso { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; } = [];

        public virtual ICollection<Empresa> Empresa { get; set; } = [];

        public virtual ICollection<Catador> Catador { get; set; } = [];
    }
}