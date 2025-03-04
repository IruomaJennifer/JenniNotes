using JenniNotes.Domain;
using JenniNotes.Infrastructure;
using JenniNotes.Infrastructure.Nhibernate;

namespace JenniNotes.Application.CreateNote
{
    public class CreateNoteService : BaseService<CreateNoteDto, string>
    {
        public CreateNoteService(DatabasePipeline pipeline, ILogger<CreateNoteService> logger, DbContext dbContext)
        {
            Pipeline = pipeline;
            Logger = logger;
            DbContext = dbContext;
        }

        public override async Task<Output<string>> ExecuteAsync(CreateNoteDto request)
        {
            var note = new Note(request.Caption, request.Description);
            foreach(var chore in request.Chores)
            {
                note.AddAChore(new Chore(chore.Description, chore.DueDate).SetNote(note));
            }
            await DbContext.NotesRepository.MakeANote(note);
            Logger.LogInformation("commiting new note to DB..");

            await Pipeline.CommitAsync();
            return await SuccessfulResult(note.Id.ToString("N"));
        }
    }
}
