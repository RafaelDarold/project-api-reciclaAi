namespace project_api_reciclaAi.Dtos.Avaliacao
{
    public class AvaliacaoRequestDto
    {
        public int SatisfacaoColeta { get; set; }
        public string? Observacao { get; set; }
        public int ColetaId { get; set; }
        public int ClienteId { get; set; }
    }
}