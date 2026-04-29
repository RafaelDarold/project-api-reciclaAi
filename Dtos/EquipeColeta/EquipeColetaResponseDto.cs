namespace project_api_reciclaAi.Dtos.EquipeColeta
{
    public class EquipeColetaResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public EmpresaResponseDto? Empresa { get; set; }
    }
}