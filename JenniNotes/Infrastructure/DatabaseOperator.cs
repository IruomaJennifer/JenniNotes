using FluentMigrator.Runner;

namespace JenniNotes.Infrastructure
{
    public class DatabaseOperator
    {
        public DatabaseOperator(IServiceProvider serviceProvider, ILogger<DatabaseOperator> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseOperator> _logger;

        public void MigrateUp()
        {
            try
            {
                var migrationRunner = _serviceProvider.GetRequiredService<IMigrationRunner>();
                migrationRunner.MigrateUp();
               
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, "Error during migration");
            }
        }

        public void MigrateDown(long version)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var migrationRunner = _serviceProvider.GetRequiredService<IMigrationRunner>();
                migrationRunner.MigrateDown(version);

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, "Error during migration");
            }
        }
        
        
    }
}
