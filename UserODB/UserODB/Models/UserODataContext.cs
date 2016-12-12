using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using UserODB.Models;

namespace UserODB.Models
{
    public class UserODataContext:DbContext
    {
        public DbSet<UserOData> UsersData { get; set; }
    }
}