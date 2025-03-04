using JenniNotes.Infrastructure.Nhibernate.Repositories;

namespace JenniNotes.Infrastructure
{
    public class DbContext
    {
        public DbContext(INotesRepository notesRepository, IChoresRepository choresRepository)
        {
            ChoresRepository = choresRepository;
            NotesRepository = notesRepository;
        }
        public IChoresRepository ChoresRepository { get; set; }
        public INotesRepository NotesRepository { get; set; }
    }
}
