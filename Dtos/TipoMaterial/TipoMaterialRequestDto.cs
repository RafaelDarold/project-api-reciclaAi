namespace project_api_reciclaAi.Dtos.TipoMaterial
{
    public class TipoMaterialRequestDto
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public required string TipoPeso { get; set; }
    }
}