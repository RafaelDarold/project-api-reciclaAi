namespace project_api_reciclaAi.Dtos.Catador
{
    public class CatadorRequestDto
    {
        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        [MinLength(11, ErrorMessage = "O CPF/CNPJ deve ter no mínimo 11 caracteres.")]
        [MaxLength(20, ErrorMessage = "O CPF/CNPJ deve ter no máximo 20 caracteres.")]
        public required string CpfCnpj { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres.")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [MinLength(10, ErrorMessage = "O telefone deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "A foto é obrigatória.")]
        [MaxLength(255, ErrorMessage = "A URL da foto deve ter no máximo 255 caracteres.")]
        public required string Foto { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        [MaxLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O tipo de usuário deve ser maior que zero.")]
        public int TipoUsuarioId { get; set; }

        [Required(ErrorMessage = "A equipe de coleta é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código da equipe deve ser maior que zero.")]
        public int EquipeColetaId { get; set; }
    }
}