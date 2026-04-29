namespace project_api_reciclaAi.Dtos.EquipeColeta
{
    public class EquipeColetaRequestDto
    {
        [Required(ErrorMessage = "O nome da equipe é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [RegularExpression("^(ativa|inativa|em pausa)$",
            ErrorMessage = "O status deve ser: 'ativa', 'inativa' ou 'em pausa'.")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "O código da empresa é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código da empresa deve ser maior que zero.")]
        public int EmpresaId { get; set; }
    }
}