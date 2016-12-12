using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NewStudentsJQ.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewStudentsJQ.DAL
{
    public class StudentsDBContext:DbContext
    {
        public StudentsDBContext() : base ("StudentsDBContext"){ }
        
        public DbSet<NewStudents> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}