namespace project_api_reciclaAi.Dtos.TipoMaterial
{
    public class TipoMaterialRequestDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O tipo de peso é obrigatório.")]
        [RegularExpression("^(kg|unidade)$",
            ErrorMessage = "O tipo de peso deve ser: 'kg' ou 'unidade'.")]
        public required string TipoPeso { get; set; }
    }
}