namespace project_api_reciclaAi.Dtos.EquipeColeta
{
    public class EquipeColetaRequestDto
    {
        public required string Nome { get; set; }
        public required string Status { get; set; }
        public int EmpresaId { get; set; }
    }
}