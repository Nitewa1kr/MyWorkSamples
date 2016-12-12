using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NewStudentsJQ.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace NewStudentsJQ.DAL
{
    public class StudentsInitial :DropCreateDatabaseIfModelChanges<StudentsDBContext>
    {
        protected override void Seed(StudentsDBContext context)
        {
            context.Students.AddOrUpdate(u => u.StudentID,
                new NewStudents { Name = "Nite", Course = "SE", JoinDate = DateTime.Now.Date },
                new NewStudents { Name = "Warlock", Course = "NE", JoinDate = DateTime.Now.Date },
                new NewStudents { Name = "Warwick", Course = "Paralegal", JoinDate = DateTime.Now.Date }
            );
        }
    }
}