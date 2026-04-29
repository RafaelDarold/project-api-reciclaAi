namespace project_api_reciclaAi.Dtos.Empresa
{
    public class EmpresaUpdateDto
    {
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        [MaxLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string? Email { get; set; }

        [MinLength(10, ErrorMessage = "O telefone deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public string? Telefone { get; set; }

        [MinLength(3, ErrorMessage = "O responsável deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O responsável deve ter no máximo 150 caracteres.")]
        public string? Responsavel { get; set; }

        [MinLength(3, ErrorMessage = "A razão social deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "A razão social deve ter no máximo 150 caracteres.")]
        public string? RazaoSocial { get; set; }
    }
}