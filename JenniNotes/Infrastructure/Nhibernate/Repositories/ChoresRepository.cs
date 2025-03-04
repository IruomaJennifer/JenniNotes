
using JenniNotes.Domain;
using NHibernate.Linq;

namespace JenniNotes.Infrastructure.Nhibernate.Repositories
{
    public class ChoresRepository : Repository, IChoresRepository
    {
        public ChoresRepository(NHibernate.ISession session) : base(session)
        {
        }

        public async Task CreateAChore(Chore chore)
        {
           await _session.SaveAsync(chore);
        }

        public async Task DeleteAChore(Chore chore)
        {
            await _session.DeleteAsync(chore);
        }

        public async Task EditAChore(Chore chore)
        {
            await _session.UpdateAsync(chore);
        }

        public async Task<Chore> FetchAChore(Guid id)
        {
            return await _session.Query<Chore>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Chore>> FetchAllChores()
        {
            return await _session.Query<Chore>().ToListAsync();
        }

        public async Task<IEnumerable<Chore>> FetchChoresByNote(Guid noteId)
        {
            return await _session.Query<Chore>().Where(c=>c.Note.Id == noteId).ToListAsync();
        }
    }
}
