namespace project_api_reciclaAi.Dtos.Catador
{
    public class CatadorResponseDto
    {
        public int Id { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public TipoUsuarioResponseDto? TipoUsuario { get; set; }
        public EquipeColetaResponseDto? EquipeColeta { get; set; }
    }
}