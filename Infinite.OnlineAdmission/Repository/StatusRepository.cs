using Infinite.OnlineAdmission.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Repository
{
    public class StatusRepository : IStatusRepository        
    {
        private readonly ApplicationDbContext _Context ;
        public StatusRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task<ApplicationStatus> Update(int id, ApplicationStatus obj)
        {
            var StatusInDb = await _Context.Status.FindAsync(id);
            if (StatusInDb != null)
            {
                StatusInDb.Status = obj.Status;
                _Context.Status.Update(StatusInDb);
                await _Context.SaveChangesAsync();
                return StatusInDb;
            }
            return null;
        }
    }
}
