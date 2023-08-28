using MeowSanctuary.Data;
using MeowSanctuary.Models;
using MeowSanctuary.Models.DTOs;
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

        [HttpGet("workerById/{id}")]
        
        public async Task<IActionResult> GetWorkerById([FromRoute] Guid id)
        {
            var workerById = from worker in _sanctuaryContext.Workers
                             where worker.Id == id
                             select worker;

            return Ok(workerById);
        }

        [HttpPost("CreateWorker")]
        public async Task<IActionResult> Create(WorkerDTO workerDTO)
        {
            var newWorker = new Worker();
            newWorker.FirstName = workerDTO.FirstName;
            newWorker.LastName = workerDTO.LastName;
            newWorker.Age = workerDTO.Age;

            await _sanctuaryContext.AddAsync(newWorker);
            await _sanctuaryContext.SaveChangesAsync();
            return Ok(newWorker);


        }

    }
}
