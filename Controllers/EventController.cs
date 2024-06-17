using Microsoft.AspNetCore.Mvc;
using ParisApp.Services.EventService;

namespace ParisApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        #region Properties

        private readonly IEventService _eventServ;

        #endregion

        #region Builders

        public EventController(IEventService eventServ)
        {
            _eventServ = eventServ;
        }

        #endregion

        [HttpGet("get-event/{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            return Ok();
        }

        [HttpGet("get-events")]
        public async Task<IActionResult> GetEvents()
        {
            return Ok();
        }
    }
}
