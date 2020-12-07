using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier4.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsContext context;
        public StudentRepository(StudentsContext context)
        {
            this.context = context;
        }

        public void Add(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
           
        }

        public void Delete(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if(s1 != null)
            {
                context.Students.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(Student newStudent)
        {
            Student oldStudent = context.Students.Find(newStudent.StudentId);
            if(oldStudent != null)
            {
                oldStudent.StudentName = newStudent.StudentName;
                oldStudent.Age = newStudent.Age;
                oldStudent.BirthDate = newStudent.BirthDate;
                oldStudent.SchoolID = newStudent.SchoolID;
                context.SaveChanges();
            }
        }

        

        public IList<Student> GetAll()
        {
            return context.Students.OrderBy(x => x.StudentName).Include(x => x.School).ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Where(x => x.StudentId == id).Include(x => x.School).SingleOrDefault();
        }
        public IList<Student> FindByName(string name)
        {
            return context.Students.Where(x => x.StudentName.Contains(name)).Include(x => x.School).ToList();

        }

        public IList <Student>  GetStudentsBySchoolID(int? id)
        {
            return context.Students.Where(s => s.SchoolID.Equals(id)).OrderBy(s => s.StudentName).Include(s => s.School).ToList();
            
        }

        
    }
}
