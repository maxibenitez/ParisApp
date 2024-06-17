using Microsoft.AspNetCore.Mvc;
using ParisApp.Services.DisciplineService;

namespace ParisApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplineController : Controller
    {
        #region Properties

        private readonly IDisciplineService _discilpineServ;

        #endregion

        #region Builders

        public DisciplineController(IDisciplineService discilpineServ)
        {
           _discilpineServ = discilpineServ;
        }

        #endregion

        [HttpGet("get-disciplines")]
        public async Task<IActionResult> GetDisciplines()
        {
            throw new NotImplementedException();
        }
    }
}
