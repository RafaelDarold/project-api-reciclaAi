namespace project_api_reciclaAi.Dtos.Coleta
{
    public class ColetaRequestDto
    {
        [Required(ErrorMessage = "A data da coleta é obrigatória.")]
        public DateTime DataColeta { get; set; }

        [MaxLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "A hora da coleta é obrigatória.")]
        public TimeSpan HoraColeta { get; set; }

        [Required(ErrorMessage = "O código da solicitação é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código da solicitação deve ser maior que zero.")]
        public int SolicitacaoId { get; set; }

        [Required(ErrorMessage = "Informe ao menos um tipo de material.")]
        [MinLength(1, ErrorMessage = "A coleta deve ter ao menos um tipo de material.")]
        public List<ColetaMaterialDto> TiposMaterial { get; set; } = [];
    }
}