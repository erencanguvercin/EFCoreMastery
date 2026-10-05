namespace EFCoreMastery.Services.DTOs.Common
{
    public class PagedResultDto<T>
    {

        public PagedResultDto()
        {
            Items = Array.Empty<T>();
        }

        public PagedResultDto(IReadOnlyList<T> items, int pageNumber, int pageSize, int totalCount)
        {
            Items = items ?? Array.Empty<T>();
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public IReadOnlyList<T> Items { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages => (int)Math.Ceiling(PageSize > 0 ? (double)TotalCount / PageSize : 0);
    }
}
