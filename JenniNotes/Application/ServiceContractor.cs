using JenniNotes.Application.CreateNote;
using JenniNotes.Application.FetchNotes;

namespace JenniNotes.Application
{
    public class ServiceContractor(CreateNoteService createNote, 
                                   FetchNotesService fetchNotes)
    {
        public CreateNoteService CreateNote { get; set; } = createNote;
        public FetchNotesService FetchNotes { get; set; } = fetchNotes;
    }
}
