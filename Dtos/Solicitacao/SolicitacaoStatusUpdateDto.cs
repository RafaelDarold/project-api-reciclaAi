namespace project_api_reciclaAi.Dtos.Solicitacao
{
    public class SolicitacaoStatusUpdateDto
    {
        [Required(ErrorMessage = "O status é obrigatório.")]
        [RegularExpression("^(pendente|em andamento|concluída|cancelada)$",
            ErrorMessage = "O status deve ser: 'pendente', 'em andamento', 'concluída' ou 'cancelada'.")]
        public required string Status { get; set; }
    }
}