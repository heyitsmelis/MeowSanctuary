using MeowSanctuary.Models;
using MeowSanctuary.Models.DTOs;
using MeowSanctuary.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowSanctuary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatDTO>>> GetCats()
        {
            var jobs = (await _unitOfWork.Cats.GetAll()).Select(a => new CatDTO(a)).ToList();
            return jobs;
        }

        // GET: api/Cat/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CatDTO>> GetCat(int id)
        {
            var job = await _unitOfWork.Cats.GetById(id);

            if (job == null)
            {
                return NotFound("Cat with this id doesn't exist");
            }

            return new CatDTO(job);
        }

        // PUT: api/JobOffer/id
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutCat(int id, CatDTO cat)
        {
            var catInDb = await _unitOfWork.Cats.GetById(id);

            if (catInDb == null)
            {
                return NotFound("Cat with this id doesn't exist");
            }
            catInDb.Name = cat.Name;
            catInDb.Breed = cat.Breed;
            catInDb.Age = cat.Age;
            catInDb.Color = cat.Color;

            await _unitOfWork.Cats.Update(catInDb);
            _unitOfWork.Save();

            return Ok();
        }


        // POST: api/Cats
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CatDTO>> PostCat(CatDTO cat)

        {
            //var catToAdd = new Cat(cat);

            //await _unitOfWork.Cats.Create(catToAdd);
            //_unitOfWork.Save();

            return Ok();
        }

        // DELETE: api/Cats/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var catInDb = await _unitOfWork.Cats.GetById(id);

            if (catInDb == null)
            {
                return NotFound("Cat with this id doesn't exist");
            }

            //await _unitOfWork.Cats.Delete(catInDb);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
