using nh = NHibernate;

namespace JenniNotes.Infrastructure.Nhibernate
{
    public class Repository
    {
        public Repository(nh.ISession session)
        {
            _session = session;
        }

        protected readonly nh.ISession _session;
    }
}
