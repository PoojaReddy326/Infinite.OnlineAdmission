using Infinite.OnlineAdmission.Models;
using Infinite.OnlineAdmission.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
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
    }
}
