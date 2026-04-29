namespace project_api_reciclaAi.Dtos.Empresa
{
    public class EmpresaRequestDto
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Telefone { get; set; }
        public required string Responsavel { get; set; }
        public required string Cnpj { get; set; }
        public required string RazaoSocial { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}