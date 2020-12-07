using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier4.Models.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly StudentsContext context;
        public SchoolRepository(StudentsContext context)
        {
            this.context = context;
        }

        public void Add(School s)
        {
            context.Schools.Add(s);
            context.SaveChanges();
            
        }

        public void Delete(School s )
        {
            School s1 = context.Schools.Find(s.SchoolID);
            if (s != null)
            {
                context.Schools.Remove(s1);
                context.SaveChanges();
            }
            
        }

        

        public void Edit(School s)
        {
            School s1 = context.Schools.Find(s.SchoolID);
            if(s1 != null)
            {
                s1.SchoolName = s.SchoolName;
                s1.SchoolAdress = s.SchoolAdress;
                context.SaveChanges();
              
            }
        }

        public IList<School> GetAll()
        {
            return context.Schools.ToList();
        }

        public School GetById(int id)
        {
            return context.Schools.Find(id);
        }

        public int StudentCount(int id)
        {
            return context.Students.Where(s => s.SchoolID == id).Count();
        }
        public double StudentAgeAverage(int id)
        {
            if (StudentCount(id) == 0)
                return 0;
            else
                return context.Students.Where(s => s.SchoolID == id).Average(e => e.Age);

        }
    }
}
