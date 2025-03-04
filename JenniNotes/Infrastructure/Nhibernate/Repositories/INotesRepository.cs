using JenniNotes.Domain;

namespace JenniNotes.Infrastructure.Nhibernate.Repositories
{
    public interface INotesRepository
    {
        Task<IEnumerable<Note>> FetchAllNotes();
        Task<Note> FetchANote(Guid id);
        Task MakeANote(Note note);
        Task UpdateANote(Note note);
        Task DeleteANote(Note note);
    }
}
