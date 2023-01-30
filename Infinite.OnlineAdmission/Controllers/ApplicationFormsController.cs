using Infinite.OnlineAdmission.Models;
using Infinite.OnlineAdmission.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormsController : ControllerBase
    {
        private readonly IFormRepository _formRepository;

        public ApplicationFormsController(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        [HttpGet]
        [Route("GetAllForms")]
        public IEnumerable<ApplicationForm> GetForms()
        {
            return _formRepository.GetAll();
        }

        [HttpGet]
        [Route("GetFormsById/{Id}", Name = "GetFormsById")]
        public async Task<ActionResult> GetById(int Id)
        {
            var form = await _formRepository.GetById(Id);
            if (form != null)
            {
                return Ok(form);
            }
            return NotFound();
        }

        [HttpPost("CreateForm")]
        public async Task<ActionResult> CreateForm([FromBody] ApplicationForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _formRepository.Create(form);
            return CreatedAtRoute("GetFormsById", new { id = form.Id }, form);
        }

        [HttpPut("UpdateForm/{Id}")]
        public async Task<IActionResult> UpdateForm(int Id, [FromBody] ApplicationForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _formRepository.Update(Id, form);
            if (result != null) 
            {
                return NoContent();
            }
            return NotFound("Form Not Exists");
        }

        [HttpDelete("DeleteForm/{Id}")]
        public async Task<ActionResult> DeleteForm(int Id)
        {
            var result = await _formRepository.Delete(Id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Adimission Form Not Exists");
        }
    }
}
