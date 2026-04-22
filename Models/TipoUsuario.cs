using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("nivel_acesso")]
        public int NivelAcesso { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; } = [];

        public virtual ICollection<Empresa> Empresas { get; set; } = [];

        public virtual ICollection<Catador> Catadores { get; set; } = [];
    }
}