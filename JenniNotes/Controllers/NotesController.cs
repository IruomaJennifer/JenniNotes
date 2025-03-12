using JenniNotes.Application;
using JenniNotes.Application.CreateNote;
using JenniNotes.Application.FetchNotes;
using JenniNotes.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenniNotes.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController(ServiceContractor serviceContractor) : BaseController(serviceContractor)
    {
        [HttpGet]
        public async Task<IActionResult> FetchAllNotes([FromQuery]int currentPage = 1, [FromQuery]int pageSize = 2)
        {
            
            var result = await _serviceContractor.FetchNotes
                               .ExecuteAsync(new PaginatedRequest { CurrentPage = currentPage, PageSize = pageSize });
            return result.Response();
        }

        [HttpPost]
        public async Task<IActionResult> MakeNote(CreateNoteDto createNoteDto)
        {
            var result = await _serviceContractor.CreateNote
                                .ExecuteAsync(createNoteDto);
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
