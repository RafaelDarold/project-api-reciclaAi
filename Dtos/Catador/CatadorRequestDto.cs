namespace project_api_reciclaAi.Dtos.Catador
{
    public class CatadorRequestDto
    {
        public required string CpfCnpj { get; set; }
        public required string Senha { get; set; }
        public required string Telefone { get; set; }
        public required string Foto { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public int TipoUsuarioId { get; set; }
        public int EquipeColetaId { get; set; }
    }
}