namespace project_api_reciclaAi.Dtos.Cliente
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string TipoPessoa { get; set; } = string.Empty;
        public TipoUsuarioResponseDto? TipoUsuario { get; set; }
        public List<EnderecoResponseDto> Enderecos { get; set; } = [];
    }
}