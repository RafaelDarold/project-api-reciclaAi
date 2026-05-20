using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Chave_Autenticacao")]
    public class ChaveAutenticacao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("chave_hash")]
        public required string ChaveHash { get; set; }

        [Column("usuario_tipo")]
        public required string UsuarioTipo { get; set; }

        [Column("usuario_id")]
        public ulong UsuarioId { get; set; }

        [Column("criado_em")]
        public DateTime CriadoEm { get; set; }

        [Column("expira_em")]
        public DateTime ExpiraEm { get; set; }

        [Column("revogada_em")]
        public DateTime? RevogadaEm { get; set; }
    }
}
