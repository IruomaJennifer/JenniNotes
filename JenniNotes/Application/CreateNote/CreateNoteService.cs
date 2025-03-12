using JenniNotes.Domain;
using JenniNotes.Infrastructure;
using JenniNotes.Infrastructure.Nhibernate;

namespace JenniNotes.Application.CreateNote
{
    public class CreateNoteService(DbContext dbContext, DatabasePipeline pipeline, ILogger<BaseService> logger) : BaseService<CreateNoteDto, string>(dbContext, pipeline, logger)
    {
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
