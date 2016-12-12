namespace NewStudentsJQ.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using NewStudentsJQ.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NewStudentsJQ.DAL.StudentsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewStudentsJQ.DAL.StudentsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Students.AddOrUpdate(u => u.StudentID,
                new NewStudents { Name = "Nite", Course = "SE", JoinDate = DateTime.Now.Date },
                new NewStudents { Name = "Warlock", Course = "NE", JoinDate = DateTime.Now.Date },
                new NewStudents { Name = "Warwick", Course = "Paralegal", JoinDate = DateTime.Now.Date }
            );
        }
    }
}
