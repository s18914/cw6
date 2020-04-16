using cw6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        public Student GetStudent(string index)
        {
            if(index == "s18914")
            {
                return new Student { IdStudent = 1, FirstName ="Emilia", LastName ="Cholewicka" };
            }
            return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            return null;
        }
    }
}
