namespace project_api_reciclaAi.Dtos.Coleta
{
    public class ColetaRequestDto
    {
        public DateTime DataColeta { get; set; }
        public string? Observacao { get; set; }
        public TimeSpan HoraColeta { get; set; }
        public int SolicitacaoId { get; set; }
        public List<ColetaMaterialDto> TiposMaterial { get; set; } = [];
    }
}