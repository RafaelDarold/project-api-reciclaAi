using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Catador")]
    public class Catador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cpf_cnpj")]
        public required string CpfCnpj { get; set; }

        [Column("senha")]
        public required string Senha { get; set; }

        [Column("telefone")]
        public required string Telefone { get; set; }

        [Column("foto")]
        public required string Foto { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("tipo_usuario_id")]
        public int TipoUsuarioId { get; set; }

        [ForeignKey(nameof(TipoUsuarioId))]
        public virtual TipoUsuario? TipoUsuario { get; set; }

        [Column("equipe_coleta_id")]
        public int EquipeColetaId { get; set; }

        [ForeignKey(nameof(EquipeColetaId))]
        public virtual EquipeColeta? EquipeColeta { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; } = [];
    }
}