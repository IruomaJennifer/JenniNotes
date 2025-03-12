using FluentMigrator.Runner;
using JenniNotes.Infrastructure.Nhibernate;
using JenniNotes.Infrastructure.Nhibernate.Repositories;
using nH = NHibernate;
using System.Runtime.CompilerServices;
using JenniNotes.Application.CreateNote;
using JenniNotes.Application.FetchNotes;
using JenniNotes.Application;

namespace JenniNotes.Infrastructure.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMigration(this IServiceCollection services, string connectionString)
        {
            return services.AddFluentMigratorCore()
                           .ConfigureRunner(builder => builder.AddSQLite()
                                    .WithGlobalConnectionString(connectionString)
                                    .ScanIn(typeof(Repository).Assembly).For.Migrations())
                           .AddScoped(typeof(nH.ISession), s => new NHibernateService(connectionString).NewSession());


        }

        public static IServiceCollection BuildDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(DatabaseOperator))
                .AddScoped(typeof(DatabasePipeline))
                .AddScoped<INotesRepository, NotesRepository>()
                .AddScoped<IChoresRepository, ChoresRepository>()
                .AddScoped<DbContext>()
                .AddScoped<CreateNoteService>()
                .AddScoped(provider =>
                {
                    return new FetchNotesService(provider.GetRequiredService<DbContext>(), 
                                provider.GetRequiredService<ILogger<FetchNotesService>>());
                })
                .AddScoped<ServiceContractor>();
        }
    }
}

