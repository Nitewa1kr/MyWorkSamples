using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using NewUsersVERBs.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewUsersVERBs.DAL
{
    public class NewUsersDBContext : DbContext
    {
        public NewUsersDBContext() : base("UserDBContext")
        {
        }

        public DbSet<NewUsers> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}