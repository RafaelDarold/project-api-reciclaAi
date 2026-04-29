namespace project_api_reciclaAi.Dtos.Solicitacao
{
    public class SolicitacaoRequestDto
    {
        public decimal VolumeEstimado { get; set; }
        public string? Observacao { get; set; }
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; }
        public List<SolicitacaoMaterialDto> TiposMaterial { get; set; } = [];
    }
}