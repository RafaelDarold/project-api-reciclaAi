namespace project_api_reciclaAi.Dtos.Endereco
{
    public class EnderecoRequestDto
    {
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [MinLength(8, ErrorMessage = "O CEP deve ter no mínimo 8 caracteres.")]
        [MaxLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        public required string Cep { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [MinLength(2, ErrorMessage = "O estado deve ter no mínimo 2 caracteres.")]
        [MaxLength(50, ErrorMessage = "O estado deve ter no máximo 50 caracteres.")]
        public required string Estado { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        [MaxLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres.")]
        public required string Numero { get; set; }

        [Required(ErrorMessage = "O país é obrigatório.")]
        [MinLength(2, ErrorMessage = "O país deve ter no mínimo 2 caracteres.")]
        [MaxLength(50, ErrorMessage = "O país deve ter no máximo 50 caracteres.")]
        public required string Pais { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória.")]
        [MinLength(3, ErrorMessage = "A rua deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "A rua deve ter no máximo 150 caracteres.")]
        public required string Rua { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [MinLength(3, ErrorMessage = "O bairro deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
        public required string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [MinLength(3, ErrorMessage = "A cidade deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
        public required string Cidade { get; set; }

        [MaxLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
        public string? Observacao { get; set; }
    }
}