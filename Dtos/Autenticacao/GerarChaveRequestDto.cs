namespace project_api_reciclaAi.Dtos.Autenticacao
{
    public class GerarChaveRequestDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public required string Email { get; set; }
    }
}
