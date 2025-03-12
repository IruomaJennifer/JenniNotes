namespace JenniNotes.Application.FetchNotes
{
    public class FetchNoteDto
    {
        public string NoteId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public IEnumerable<FetchChoreDto> Chores { get; set; }
    }
}
