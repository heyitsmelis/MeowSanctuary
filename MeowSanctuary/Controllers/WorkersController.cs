using MeowSanctuary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private SanctuaryContext _sanctuaryContext;

        public WorkersController(SanctuaryContext sanctuaryContext)
        {
            _sanctuaryContext = sanctuaryContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            return Ok(await _sanctuaryContext.Workers.ToListAsync());
        }
    }
}
