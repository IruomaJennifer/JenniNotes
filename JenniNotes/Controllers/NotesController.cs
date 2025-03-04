using JenniNotes.Application.CreateNote;
using JenniNotes.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenniNotes.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public NotesController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        private readonly IServiceProvider _serviceProvider;
        [HttpGet]
        public IActionResult FetchAllNotes()
        {
            
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> MakeNote(CreateNoteDto createNoteDto)
        {
           using var scope =  _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<CreateNoteService>();
            var result = await service.ExecuteAsync(createNoteDto);
            return result.Response();
        }

        [HttpPut]
        public IActionResult EditNote()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult DeleteNotes()
        {
            throw new NotImplementedException();
        }
    }
}
