namespace JenniNotes.Infrastructure.Services
{
    public static class CollectionExtensions
    {
        public static PaginatedResponse<Source> Paginate<Source>(this IQueryable<Source> source, int current, int pageSize)
        {
            var total = source.Count();
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);
            var entities = source.Skip((current - 1) * pageSize).Take(pageSize).AsEnumerable();

            return new PaginatedResponse<Source>
            {
                Entities = entities,
                Current = current,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalEntities = total
            };
        }
    }
}
