namespace project_api_reciclaAi.Dtos.Avaliacao
{
    public class AvaliacaoResponseDto
    {
        public int Id { get; set; }
        public int SatisfacaoColeta { get; set; }
        public string? Observacao { get; set; }
        public ColetaResponseDto? Coleta { get; set; }
        public ClienteResponseDto? Cliente { get; set; }
    }
}