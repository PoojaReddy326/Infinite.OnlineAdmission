using Infinite.OnlineAdmission.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Repository
{
    public class DocumentsRepository : IDocumentsRepository<Documents>, IDocumentsGetRepository<Documents>
    {
        private readonly ApplicationDbContext _dbContext;
        public DocumentsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Documents obj)
        {
            if (obj != null)
            {
                _dbContext.Uploads.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Documents>> GetAll()
        {
            return await _dbContext.Uploads.ToListAsync();
        }
        public async Task<Documents> GetById(int id)
        {
            var image = await _dbContext.Uploads.FirstOrDefaultAsync(s => s.Id == id);
            if (image != null)
            {
                return image;
            }
            return null;
        }
    }
}
