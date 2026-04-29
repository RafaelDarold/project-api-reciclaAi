namespace project_api_reciclaAi.Dtos.Foto
{
    public class FotoRequestDto
    {
        [Required(ErrorMessage = "A URL da foto é obrigatória.")]
        [Url(ErrorMessage = "A URL da foto informada não é válida.")]
        [MaxLength(255, ErrorMessage = "A URL deve ter no máximo 255 caracteres.")]
        public required string Url { get; set; }

        [Required(ErrorMessage = "O código da solicitação é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código da solicitação deve ser maior que zero.")]
        public int SolicitacaoId { get; set; }
    }
}