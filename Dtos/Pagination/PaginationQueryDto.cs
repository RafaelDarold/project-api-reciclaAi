namespace project_api_reciclaAi.Dtos.Pagination
{
    public class PaginationQueryDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "A página deve ser maior que zero.")]
        public int Page { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "O tamanho da página deve estar entre 1 e 100.")]
        public int PageSize { get; set; } = 10;
    }
}
