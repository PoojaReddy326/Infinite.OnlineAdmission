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
        public readonly IPaymentRepository _paymentRepository;

        public CourseController(IRepository<Course> repository, IPaymentRepository paymentRepository)
        {
            _repository = repository;            
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("DisplayCourses")]
        public IEnumerable<Course> GetCourses()
        {
            return _repository.DisplayCourses();
        }

        [HttpPut("UpdateCourse/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Course course)
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
    }
}
