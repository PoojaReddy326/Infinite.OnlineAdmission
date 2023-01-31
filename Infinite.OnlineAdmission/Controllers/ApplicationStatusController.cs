using Infinite.OnlineAdmission.Models;
using Infinite.OnlineAdmission.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public ApplicationStatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpPut("UpdateStatus/{id}")]

        public async Task<IActionResult> UpdateStatus(int id, [FromBody] ApplicationStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _statusRepository.Update(id, status);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound("Error");
        }

        //[HttpGet]
        //[Route("GetByStatus/{status}")]
        //public async Task<IActionResult> GetByStatus(string Status)
        //{
        //    var result = await _statusRepository.GetByStatus(Status);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound();      
        //}

        [HttpGet]
        [Route("DisplayStatus")]
        public IEnumerable<ApplicationStatus> GetAll()
        {
            return _statusRepository.GetAll();
        }
    }
}
