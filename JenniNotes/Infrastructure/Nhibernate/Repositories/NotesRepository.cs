
using JenniNotes.Domain;
using NHibernate.Linq;

namespace JenniNotes.Infrastructure.Nhibernate.Repositories
{
    public class NotesRepository : Repository, INotesRepository
    {
        public NotesRepository(NHibernate.ISession session) : base(session)
        {
        }

        public async Task DeleteANote(Note note)
        {
            await _session.DeleteAsync(note);
        }

        public async Task<IEnumerable<Note>> FetchAllNotes()
        {
           return await _session.Query<Note>().ToListAsync();
        }

        public async Task<Note> FetchANote(Guid id)
        {
            return await _session.Query<Note>().FirstOrDefaultAsync(n=>n.Id == id);
        }

        public async Task MakeANote(Note note)
        {
            await _session.SaveAsync(note);
        }

        public async Task UpdateANote(Note note)
        {
            await _session.UpdateAsync(note);
        }
    }
}
