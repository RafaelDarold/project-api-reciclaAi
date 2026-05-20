using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("tipoPessoa")]
        public required string TipoPessoa { get; set; }

        [Column("perfil")]
        public required string Perfil { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

        [Column("criado_em")]
        public DateTime CriadoEm { get; set; }

        [Column("atualizado_em")]
        public DateTime AtualizadoEm { get; set; }
    }
}
