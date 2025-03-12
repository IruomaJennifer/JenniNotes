using JenniNotes.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenniNotes.Controllers
{
    
    public class BaseController(ServiceContractor serviceContractor) : ControllerBase
    {
        protected readonly ServiceContractor _serviceContractor = serviceContractor;
    }
}
