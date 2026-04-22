using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("senha")]
        public required string Senha { get; set; }

        [Column("telefone")]
        public required string Telefone { get; set; }

        [Column("responsavel")]
        public required string Responsavel { get; set; }

        [Column("cnpj")]
        public required string Cnpj { get; set; }

        [Column("razaoSocial")]
        public required string RazaoSocial { get; set; }

        [Column("tipo_usuario_id")]
        public int TipoUsuarioId { get; set; }

        [ForeignKey(nameof(TipoUsuarioId))]
        public virtual TipoUsuario? TipoUsuario { get; set; }

        public virtual ICollection<EquipeColeta> EquipesColeta { get; set; } = [];
    }
}