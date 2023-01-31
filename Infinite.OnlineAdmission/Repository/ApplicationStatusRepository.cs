using Infinite.OnlineAdmission.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Repository
{
    public class ApplicationStatusRepository : IStatusRepository        
    {
        private readonly ApplicationDbContext _Context ;
        public ApplicationStatusRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        //public async Task<ApplicationStatus> GetByStatus(string status)
        //{
        //    var statuses = await _Context.Status.FindAsync(status);
        //    if (status != null)
        //    {
        //        return statuses;
        //    }
        //    return null;
        //}

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

        IEnumerable<ApplicationStatus> IStatusRepository.GetAll()
        {
           return _Context.Status.ToList();
        }
    }
}
