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
            Task<Course> GetById(int Id);
        }

        public interface IStatusRepository
        {
            Task<ApplicationStatus> Update(int id, ApplicationStatus obj);

            //Task<ApplicationStatus> GetByStatus(string status);

            IEnumerable<ApplicationStatus> GetAll();
       
        }

        public interface IPaymentRepository
        {
            IEnumerable<Payment> DisplayPayments();

            Task<Payment> GetById(int id);

        }

        public interface IFormRepository
        {
            IEnumerable<ApplicationForm> GetAll();
            Task<ApplicationForm> GetById(int Id);
            Task<ApplicationForm> Create(ApplicationForm obj);
            Task<ApplicationForm> Update(int Id, ApplicationForm obj);
            Task<ApplicationForm> Delete(int Id);
            Task<IEnumerable<ApplicationForm>> SearchByphn(string phonenumber);
            Task<IEnumerable<ApplicationForm>> SearchByemail(string email);
            //Task<IEnumerable<AdmissionFormDto>> SearchByStatus(string status);
        }
        //public interface IImageRepository
        //{
        //    Task<int> Add(FileUpload image);
        //    Task<FileUpload> Get(int id);
        //    IEnumerable<FileUpload> GetAll();
        //    Task<FileUpload> Delete(int id);
        //}
         public interface IAdminRepository
         {
         IEnumerable<RegUser> GetAll();
         Task<RegUser> Update(int id, RegUser obj);
         }

        public interface IDocumentsRepository<T> where T : class
        {
            Task Create(T obj);
        }
        public interface IDocumentsGetRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAll(); Task<T> GetById(int id);
        }
    }
}
