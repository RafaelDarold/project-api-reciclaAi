namespace project_api_reciclaAi.Dtos.Empresa
{
    public class EmpresaRequestDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        [MaxLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres.")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [MinLength(10, ErrorMessage = "O telefone deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "O responsável é obrigatório.")]
        [MinLength(3, ErrorMessage = "O responsável deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O responsável deve ter no máximo 150 caracteres.")]
        public required string Responsavel { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [MinLength(14, ErrorMessage = "O CNPJ deve ter no mínimo 14 caracteres.")]
        [MaxLength(20, ErrorMessage = "O CNPJ deve ter no máximo 20 caracteres.")]
        public required string Cnpj { get; set; }

        [Required(ErrorMessage = "A razão social é obrigatória.")]
        [MinLength(3, ErrorMessage = "A razão social deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "A razão social deve ter no máximo 150 caracteres.")]
        public required string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O tipo de usuário deve ser maior que zero.")]
        public int TipoUsuarioId { get; set; }
    }
}