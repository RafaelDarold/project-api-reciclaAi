namespace project_api_reciclaAi.Dtos.Cliente
{
    public class ClienteUpdateDto
    {
        [MaxLength(255, ErrorMessage = "A URL da foto deve ter no máximo 255 caracteres.")]
        public string? Foto { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        [MaxLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string? Email { get; set; }

        [MinLength(3, ErrorMessage = "O responsável deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O responsável deve ter no máximo 150 caracteres.")]
        public string? Responsavel { get; set; }

        [MinLength(10, ErrorMessage = "O telefone deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public string? Telefone { get; set; }

        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string? Nome { get; set; }
    }
}