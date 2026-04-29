namespace project_api_reciclaAi.Dtos.Foto
{
    public class FotoResponseDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int SolicitacaoId { get; set; }
    }
}