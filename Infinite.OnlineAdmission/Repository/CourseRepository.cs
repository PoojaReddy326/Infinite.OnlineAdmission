using Infinite.OnlineAdmission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly ApplicationDbContext _Context;

        public CourseRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task Create(Course obj)
        {
            if (obj != null)
            {
                _Context.Courses.Add(obj);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task<Course> Delete(int CourseId)
        {
            var CourseInDb = await _Context.Courses.FindAsync(CourseId);
            if (CourseInDb != null)
            {
                _Context.Courses.Remove(CourseInDb);
                await _Context.SaveChangesAsync();
                return CourseInDb;
            }
            return null;
        }

        [HttpGet]
        [Route("Get All Courses")]
        public IEnumerable<Course> DisplayCourses()
        {
            return _Context.Courses.ToList();
        }

        public async Task<Course> Update(int id, Course obj)
        {
            var CourseInDb = await _Context.Courses.FindAsync(id);
            if (CourseInDb != null)
            {
                CourseInDb.CourseName = obj.CourseName;
                _Context.Courses.Update(CourseInDb);
                await _Context.SaveChangesAsync();
                return CourseInDb;
            }
            return null;
        }
       
    }
}
