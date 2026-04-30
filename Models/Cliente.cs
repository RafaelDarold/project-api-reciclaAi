using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cpf_cnpj")]
        public required string CpfCnpj { get; set; }

        [Column("foto")]
        public required string Foto { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("senha")]
        public required string Senha { get; set; }

        [Column("responsavel")]
        public required string Responsavel { get; set; }

        [Column("telefone")]
        public required string Telefone { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("tipoPessoa")]
        public required string TipoPessoa { get; set; }

        [Column("tipo_usuario_id")]
        public int TipoUsuarioId { get; set; }

        [ForeignKey(nameof(TipoUsuarioId))]
        public virtual TipoUsuario? TipoUsuario { get; set; }

        public virtual ICollection<ClienteEndereco> Endereco { get; set; } = [];

       public virtual ICollection<Solicitacao> Solicitacao { get; set; } = [];

       public virtual ICollection<Avaliacao> Avaliacao { get; set; } = [];
    }
}