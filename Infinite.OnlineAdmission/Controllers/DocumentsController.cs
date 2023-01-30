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
        private readonly IImageRepository _imageRepository;
        public DocumentsController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        [HttpGet("GetAllImages")]
        public IEnumerable<FileUpload> GetImages()
        {
            return _imageRepository.GetAll();
        }
        [HttpGet("GetImagesById")]
        public async Task<ActionResult> Get(int id)
        {
            var image = await _imageRepository.Get(id);
            if (image != null)
            {
                return Ok(image);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            //Read the file into a byte array
            byte[] fileData;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                fileData = stream.ToArray();
            }
            //Create the image object
            var image = new FileUpload { FileName = file.FileName, FileData = fileData };
            //Save the image to the database
            var id = await _imageRepository.Add(image);
            return Ok("Success");
        }
        [HttpDelete("DeleteImage/{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            var result = await _imageRepository.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Image Doesnot Exists");
        }
    }
}
