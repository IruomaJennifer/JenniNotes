namespace JenniNotes.Application.CreateNote
{
    public class CreateNoteDto
    {
        public string Caption {  get; set; }
        public string Description {  get; set; }
        public IEnumerable<CreateChoreDto> Chores { get; set; }


    }
}
