using Infinite.OnlineAdmission.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
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

            Task<ApplicationStatus> GetByStatus(string status);

            IEnumerable<ApplicationStatus> GetAll();
       
        }

        public interface IPaymentRepository
        {
            IEnumerable<Payment> DisplayPayments();

            Task<Payment> GetById(int id);

        }

        public interface IFormRepository
        {
            IEnumerable<AdmissionForm> GetAll();
            Task<AdmissionForm> GetById(int Id);
            Task<AdmissionForm> Create(AdmissionForm obj);
            Task<AdmissionForm> Update(int Id, AdmissionForm obj);
            Task<AdmissionForm> Delete(int Id);
        }
    }
}
