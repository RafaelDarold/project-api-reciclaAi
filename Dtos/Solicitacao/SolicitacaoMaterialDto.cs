namespace project_api_reciclaAi.Dtos.Solicitacao
{
    public class SolicitacaoMaterialDto
    {
        [Required(ErrorMessage = "O tipo de material é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O tipo de material deve ser maior que zero.")]
        public int TipoMaterialId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public decimal Quantidade { get; set; }
    }
}