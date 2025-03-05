namespace JenniNotes.Infrastructure.Services
{
    public class PaginatedResponse<Response>
    {
        public int Current { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalEntities { get; set; }
        public IEnumerable<Response> Entities { get; set; }
    }
}
