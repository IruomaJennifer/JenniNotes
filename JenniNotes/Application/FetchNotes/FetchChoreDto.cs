namespace JenniNotes.Application.FetchNotes
{
    public class FetchChoreDto
    {
        public Guid ChoreId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
