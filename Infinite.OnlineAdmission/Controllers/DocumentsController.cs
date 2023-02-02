using Infinite.OnlineAdmission.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Infinite.OnlineAdmission.Repository.IRepository;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsRepository<Documents> _repository;
        private readonly IDocumentsGetRepository<Documents> _getrepository;
        public DocumentsController(IDocumentsRepository<Documents> repository, IDocumentsGetRepository<Documents> getrepository)
        {
            _getrepository = getrepository;
            _repository = repository;
        }
        //[Authorize(Roles = "Admin,Student")]
        [HttpGet("GetAllUploadImages")]
        public async Task<IEnumerable<Documents>> GetAllImages()
        {
            return await _getrepository.GetAll();
        }
        //[Authorize(Roles = "Admin,Student")]
        [HttpGet]
        [Route("GetImageById/{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _getrepository.GetById(id);
            if (image != null)
            {
                return Ok(image);
            }
            return NotFound();
        }
        //[Authorize(Roles = "Student")]
        [HttpPost("CreateImage")]
        public async Task<IActionResult> Create([FromBody] Documents image)
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(image);
                return CreatedAtAction("GetImageById", new { id = image.Id }, image);
            }
            return BadRequest();
        }
    }
}
