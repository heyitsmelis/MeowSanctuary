using MeowSanctuary.Models;
using MeowSanctuary.Models.DTOs;
using MeowSanctuary.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeowSanctuary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShelterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // END-POINTS

        // GET: api/Shelters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelterDTO>>> GetShelters()
        {
            var shelters = (await _unitOfWork.Shelters.GetAll()).Select(a => new ShelterDTO(a)).ToList();
            return shelters;
        }

        // GET: api/Shelter/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelterDTO>> GetShelter(int id)
        {
            var shelter = await _unitOfWork.Shelters.GetById(id);

            if (shelter == null)
            {
                return NotFound("Shelter with this id doesn't exist");
            }

            return new ShelterDTO(shelter);
        }


        // PUT: api/Shelters/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutShelter(int id, ShelterDTO shelter)
        {
            var shelterInDb = await _unitOfWork.Shelters.GetById(id);

            if (shelterInDb == null)
            {
                return NotFound("Shelter with this id doesn't exist");
            }

            shelterInDb.Name = shelter.Name;
            shelterInDb.Address = shelter.Address;


            await _unitOfWork.Shelters.Update(shelterInDb);
            _unitOfWork.Save();

            return Ok();
        }

        // POST: api/Shelters
        [HttpPost]
        public async Task<ActionResult<ShelterDTO>> PostShelter(ShelterDTO shelter)
        {

            var shelterToAdd = new Shelter(shelter);

            await _unitOfWork.Shelters.Create(shelterToAdd);
            _unitOfWork.Save();

            return Ok();
        }

        // DELETE: api/Shelters/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteShelters(int id)
        {
            var shelterInDb = await _unitOfWork.Shelters.GetById(id);

            if (shelterInDb == null)
            {
                return NotFound("Shelter with this id doesn't exist");
            }

            await _unitOfWork.Shelters.Delete(shelterInDb);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
