namespace project_api_reciclaAi.Dtos.Empresa
{
    public class EmpresaResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public TipoUsuarioResponseDto? TipoUsuario { get; set; }
    }
}