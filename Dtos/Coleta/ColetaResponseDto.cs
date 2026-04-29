namespace project_api_reciclaAi.Dtos.Coleta
{
    public class ColetaResponseDto
    {
        public int Id { get; set; }
        public DateTime DataColeta { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Observacao { get; set; }
        public decimal PesoTotal { get; set; }
        public TimeSpan HoraColeta { get; set; }
        public SolicitacaoResponseDto? Solicitacao { get; set; }
        public List<ColetaMaterialDto> TiposMaterial { get; set; } = [];
    }
}