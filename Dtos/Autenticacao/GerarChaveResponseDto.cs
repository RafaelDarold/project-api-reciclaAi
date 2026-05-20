namespace project_api_reciclaAi.Dtos.Autenticacao
{
    public class GerarChaveResponseDto
    {
        public string ChaveAutenticacao { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
        public ulong UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime ExpiraEm { get; set; }
    }
}
