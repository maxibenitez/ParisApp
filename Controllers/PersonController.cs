using Microsoft.AspNetCore.Mvc;
using ParisApp.Services.PersonService;

namespace ParisApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        #region Properties

        private readonly IPersonService _personServ;

        #endregion

        #region Builders

        public PersonController(IPersonService personServ)
        {
            _personServ = personServ;
        }

        #endregion

        [HttpGet("get-person/{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            return Ok(await _personServ.GetPerson(id));
        }
    }
}
