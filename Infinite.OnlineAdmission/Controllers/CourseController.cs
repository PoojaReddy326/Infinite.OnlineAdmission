using Infinite.OnlineAdmission.Models;
using Infinite.OnlineAdmission.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _repository;
        public readonly IStatusRepository _statusRepository;

        public CourseController(IRepository<Course> repository, IStatusRepository statusRepository)
        {
            _repository = repository;
            _statusRepository = statusRepository;
        }
        [HttpGet]
        [Route("DisplayCourses")]
        public IEnumerable<Course> GetCourses()
        {
            return _repository.DisplayCourses();
        }

        [HttpPut("UpdateCourse/{id}")]
        public async Task<ActionResult> Updtae(int id, [FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _repository.Update(id, course);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound("No Result Found");
        }

        [HttpDelete("DeleteCourse/{id}")]

        public async Task<ActionResult> DeleteCourse(int id)
        {
            var result = await _repository.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Course Not Found");
        }

        [HttpPost("CreateCourse")]
        public async Task<ActionResult> CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.Create(course);
            return CreatedAtRoute("GetCourseById", new { id = course.CourseId });
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] ApplicationStatus status)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _repository.Update(id, status);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound("Error");            
        }
    }
}
