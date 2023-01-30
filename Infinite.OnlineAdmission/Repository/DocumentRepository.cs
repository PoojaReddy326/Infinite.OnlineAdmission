using Infinite.OnlineAdmission.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Repository
{
    public class DocumentRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(FileUpload image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image.Id;
        }

        public async Task<FileUpload> Delete(int id)
        {
            var ImageInDb = await _context.Images.FindAsync(id);
            if (ImageInDb != null)
            {
                _context.Images.Remove(ImageInDb);
                await _context.SaveChangesAsync();
                return ImageInDb;
            }
            return null;
        }


        public async Task<FileUpload> Get(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public IEnumerable<FileUpload> GetAll()
        {
            return _context.Images.ToList();
        }
    }
}
