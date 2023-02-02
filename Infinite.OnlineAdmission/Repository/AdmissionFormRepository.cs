using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Infinite.OnlineAdmission.Models;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.Users.Repositories
{
    public class AdmissionFormRepository : IFormRepository
    {
        private readonly ApplicationDbContext _context;
        public AdmissionFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }       

        [HttpPost]
        public async Task<ApplicationForm> Delete(int Id)
        {
            var FormInDb = await _context.forms.FindAsync(Id);
            if (FormInDb != null)
            {
                _context.forms.Remove(FormInDb);
                await _context.SaveChangesAsync();
                return FormInDb;
            }
            return null;
        }

        public IEnumerable<ApplicationForm> GetAll()
        {
            return _context.forms.ToList();
        }

        public async Task<ApplicationForm> GetById(int Id)
        {
            var form = await _context.forms.FindAsync(Id);
            if (form != null)
            {
                return form;

            }
            return null;
        }        

        public async Task<ApplicationForm> Update(int Id, ApplicationForm obj)
        {

            var FormInDb = await _context.forms.FindAsync(Id);
            if (FormInDb != null)
            {
                FormInDb.FatherName = obj.FatherName;
                FormInDb.Address = obj.Address;
                FormInDb.City = obj.City;
                FormInDb.State = obj.State;
                FormInDb.MotherName = obj.MotherName;
                FormInDb.PhoneNumber = obj.PhoneNumber;
                FormInDb.LastName = obj.LastName;
                FormInDb.FirstName = obj.FirstName;
                FormInDb.EmailId = obj.EmailId;
                FormInDb.Gender = obj.Gender;
                FormInDb.DateOfBirth = obj.DateOfBirth;
                _context.forms.Update(FormInDb);
                await _context.SaveChangesAsync();
                return FormInDb;
            }
            return null;
        }

        public async Task<ApplicationForm> Create(ApplicationForm obj)
        {
            if (obj != null)
            {
                _context.forms.Add(obj);
                await _context.SaveChangesAsync();
            }
            return null;

        }
        public async Task<IEnumerable<ApplicationForm>> SearchByphn(string phonenumber)
        {
            if(!string.IsNullOrWhiteSpace(phonenumber))
            {
                var employeeRoster = await _context.forms.Where(x => x.PhoneNumber.Contains(phonenumber)).ToListAsync();
                return employeeRoster;
            }
            return null;
        }

        public async Task<IEnumerable<ApplicationForm>> SearchByemail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                var employeeRoster = await _context.forms.Where(x => x.EmailId.Contains(email)).ToListAsync();
                return employeeRoster;
            }
            return null;
        }
    }
}
