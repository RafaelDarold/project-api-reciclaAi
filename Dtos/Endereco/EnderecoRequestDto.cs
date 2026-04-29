namespace project_api_reciclaAi.Dtos.Endereco
{
    public class EnderecoRequestDto
    {
        public required string Cep { get; set; }
        public required string Estado { get; set; }
        public required string Numero { get; set; }
        public required string Pais { get; set; }
        public required string Rua { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public string? Observacao { get; set; }
    }
}