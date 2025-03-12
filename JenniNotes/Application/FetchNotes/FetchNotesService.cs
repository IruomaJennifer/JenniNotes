using JenniNotes.Domain;
using JenniNotes.Infrastructure;
using JenniNotes.Infrastructure.Nhibernate;
using JenniNotes.Infrastructure.Services;

namespace JenniNotes.Application.FetchNotes
{
    public class FetchNotesService(DbContext dbContext, ILogger<FetchNotesService> logger, DatabasePipeline pipeline = null) : BaseService<PaginatedRequest, IEnumerable<FetchNoteDto>>(dbContext, pipeline, logger)
    {
        public override async Task<Output<IEnumerable<FetchNoteDto>>> ExecuteAsync(PaginatedRequest request)
        {
            Logger.LogInformation("Checking Db for notes..");

            var paginatedNotes = DbContext.NotesRepository.QueryNotes().Paginate(request.CurrentPage, request.PageSize);

            var noteDtos = new List<FetchNoteDto>();

            foreach(var note in paginatedNotes.Entities)
            {
                var noteDto = new FetchNoteDto
                {
                    Caption = note.Caption,
                    Description = note.Description,
                    Chores = SetChores(note),
                    NoteId = note.Id.ToString("N")
                };
                noteDtos.Add(noteDto);
            }

            return await SuccessfulResult(noteDtos, paginatedNotes.Current, paginatedNotes.TotalPages, 
                                            paginatedNotes.PageSize, paginatedNotes.TotalEntities);
        }

        private List<FetchChoreDto> SetChores(Note note)
        {
            return note.Chores.Select(c => new FetchChoreDto { ChoreId = c.Id, Description = c.Description, DueDate = c.DueDate })
                .ToList();
        }
    }
}
