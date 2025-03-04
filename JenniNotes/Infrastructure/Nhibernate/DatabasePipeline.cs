using NHibernate;

namespace JenniNotes.Infrastructure.Nhibernate
{
    public class DatabasePipeline
    {
        public DatabasePipeline(NHibernate.ISession session, ILogger<DatabasePipeline> logger)
        {
            _session = session;
            _logger = logger;
        }
        private readonly NHibernate.ISession _session;
        private readonly ILogger<DatabasePipeline> _logger;

        public async Task CommitAsync()
        {
            _logger.LogInformation("Committing changes to database");
            using var transaction = _session.BeginTransaction();
            try
            {
                transaction.Commit();
                await Task.CompletedTask;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                _logger.LogWarning(ex.Message, ex);
               
            }
        }
    }
}
