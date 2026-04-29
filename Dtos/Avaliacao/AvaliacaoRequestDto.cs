namespace project_api_reciclaAi.Dtos.Avaliacao
{
    public class AvaliacaoRequestDto
    {
        [Required(ErrorMessage = "A nota de satisfação é obrigatória.")]
        [Range(1, 5, ErrorMessage = "A nota de satisfação deve ser entre 1 e 5.")]
        public int SatisfacaoColeta { get; set; }

        [MaxLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O código da coleta é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código da coleta deve ser maior que zero.")]
        public int ColetaId { get; set; }

        [Required(ErrorMessage = "O código do cliente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código do cliente deve ser maior que zero.")]
        public int ClienteId { get; set; }
    }
}