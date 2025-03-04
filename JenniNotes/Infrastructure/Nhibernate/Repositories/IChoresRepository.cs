using JenniNotes.Domain;

namespace JenniNotes.Infrastructure.Nhibernate.Repositories
{
    public interface IChoresRepository
    {
        Task<IEnumerable<Chore>> FetchChoresByNote(Guid noteId);
        Task<IEnumerable<Chore>> FetchAllChores();
        Task<Chore> FetchAChore(Guid id);
        Task CreateAChore(Chore chore);
        Task EditAChore(Chore chore);
        Task DeleteAChore(Chore chore);
    }
}
