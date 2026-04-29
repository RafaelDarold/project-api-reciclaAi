namespace project_api_reciclaAi.Dtos.Solicitacao
{
    public class SolicitacaoResponseDto
    {
        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public decimal VolumeEstimado { get; set; }
        public string? Observacao { get; set; }
        public string Status { get; set; } = string.Empty;
        public ClienteResponseDto? Cliente { get; set; }
        public EnderecoResponseDto? Endereco { get; set; }
        public EquipeColetaResponseDto? EquipeColeta { get; set; }
        public CatadorResponseDto? Catador { get; set; }
        public List<SolicitacaoMaterialDto> TiposMaterial { get; set; } = [];
    }
}