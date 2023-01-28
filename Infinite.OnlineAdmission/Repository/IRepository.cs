using Infinite.OnlineAdmission.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infinite.OnlineAdmission.Repository
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> DisplayCourses();
            Task<Course> Update(int CourseId, T obj);
            Task<Course> Delete(int CourseId);
            Task Create(T obj);
        }

        public interface IStatusRepository
        {
            Task<ApplicationStatus> Update(int id, ApplicationStatus obj);
       
        }

        public interface IPaymentRepository
        {
            IEnumerable<Payment> DisplayCourses();

        }
    }
}
