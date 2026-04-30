using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_api_reciclaAi.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("rua")]
        public required string Rua { get; set; }

        [Column("numero")]
        public required string Numero { get; set; }

        [Column("bairro")]
        public required string Bairro { get; set; }

        [Column("cidade")]
        public required string Cidade { get; set; }

        [Column("estado")]
        public required string Estado { get; set; }

        [Column("pais")]
        public required string Pais { get; set; }

        [Column("cep")]
        public required string Cep { get; set; }

        [Column("observacao")]
        public string? Observacao { get; set; }

        public virtual ICollection<ClienteEndereco> ClienteEndereco { get; set; } = [];

        public virtual ICollection<Solicitacao> Solicitacao { get; set; } = [];
    }
}