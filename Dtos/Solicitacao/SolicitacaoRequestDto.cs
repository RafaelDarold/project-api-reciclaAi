namespace project_api_reciclaAi.Dtos.Solicitacao
{
    public class SolicitacaoRequestDto
    {
        [Required(ErrorMessage = "O volume estimado é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O volume estimado deve ser maior que zero.")]
        public decimal VolumeEstimado { get; set; }

        [MaxLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O código do cliente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código do cliente deve ser maior que zero.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O código do endereço é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código do endereço deve ser maior que zero.")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Informe ao menos um tipo de material.")]
        [MinLength(1, ErrorMessage = "A solicitação deve ter ao menos um tipo de material.")]
        public List<SolicitacaoMaterialDto> TiposMaterial { get; set; } = [];
    }
}