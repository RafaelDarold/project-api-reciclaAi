using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace project_api_reciclaAi.Models
{
    [Table("Solicitacao")]
    public class Solicitacao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("dataSolicitacao")]
        public DateTime DataSolicitacao { get; set; }

        [Column("volumeEstimado")]
        public decimal VolumeEstimado { get; set; }

        [Column("observacao")]
        public required string Observacao { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente? Cliente { get; set; }

        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        [ForeignKey(nameof(EnderecoId))]
        public virtual Endereco? Endereco { get; set; }

        [Column("equipe_coleta_id")]
        public int? EquipeColetaId { get; set; }

        [ForeignKey(nameof(EquipeColetaId))]
        public virtual EquipeColeta? EquipeColeta { get; set; }

        [Column("catador_id")]
        public int? CatadorId { get; set; }

        [ForeignKey(nameof(CatadorId))]
        public virtual Catador? Catador { get; set; }

        public virtual ICollection<Foto> Fotos { get; set; } = [];

        public virtual ICollection<SolicitacaoTipoMaterial> TiposMaterial { get; set; } = [];

        public virtual ICollection<Coleta> Coletas { get; set; } = [];
    }
}