using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace project_api_reciclaAi.Services.Common
{
    public static class PaginationExtensions
    {
        public static async Task<PaginatedResponseDto<TDestination>> ToPaginatedResponseAsync<TSource, TDestination>(
            this IQueryable<TSource> query,
            PaginationQueryDto pagination,
            IMapper mapper) where TSource : class
        {
            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pagination.PageSize);

            var items = await query
                .OrderBy(entity => EF.Property<int>(entity, "Id"))
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginatedResponseDto<TDestination>
            {
                Items = mapper.Map<List<TDestination>>(items),
                Page = pagination.Page,
                PageSize = pagination.PageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                HasPreviousPage = pagination.Page > 1,
                HasNextPage = pagination.Page < totalPages
            };
        }
    }
}
