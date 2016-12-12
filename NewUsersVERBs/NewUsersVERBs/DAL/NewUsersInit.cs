using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewUsersVERBs.Models;

namespace NewUsersVERBs.DAL
{
    public class NewUsersInit : DropCreateDatabaseIfModelChanges<NewUsersDBContext>
    {
        protected override void Seed(NewUsersDBContext context)
        {

            var users = new List<NewUsers>
            {
                new NewUsers {UserHandle="Nite",UserPass="12345",JoinDate=DateTime.Now.Date },
                new NewUsers {UserHandle="Warlock",UserPass="1a2b3c",JoinDate=DateTime.Now.Date },
                new NewUsers {UserHandle="CoffeeAddict",UserPass="000123",JoinDate=DateTime.Now.Date },
                new NewUsers {UserHandle="Ned",UserPass="123000",JoinDate=DateTime.Now.Date },
                new NewUsers {UserHandle="Prev",UserPass="010203",JoinDate=DateTime.Now.Date },
            };

        }
    }
}