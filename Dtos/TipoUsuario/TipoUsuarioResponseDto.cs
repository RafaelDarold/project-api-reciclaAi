namespace project_api_reciclaAi.Dtos.TipoUsuario
{
    public class TipoUsuarioResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int NivelAcesso { get; set; }
    }
}