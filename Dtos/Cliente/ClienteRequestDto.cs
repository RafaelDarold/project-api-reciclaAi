namespace project_api_reciclaAi.Dtos.Cliente
{
    public class ClienteRequestDto
    {
        public required string CpfCnpj { get; set; }
        public required string Foto { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Responsavel { get; set; }
        public required string Telefone { get; set; }
        public required string Nome { get; set; }
        public required string TipoPessoa { get; set; }
        public int TipoUsuarioId { get; set; }
        public required EnderecoRequestDto Endereco { get; set; }
    }
}