using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using NewUsersVERBs.Models;
using NewUsersVERBs.DAL;

namespace NewUsersVERBs.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NewUsersDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewUsersDBContext context)
        {

            context.Users.AddOrUpdate(u => u.UserID,
                new NewUsers {UserHandle="Nite",UserPass="12345",JoinDate=DateTime.Now.Date },
                new NewUsers {UserHandle="Warlock",UserPass="1a2b3c",JoinDate= DateTime.Now.Date },
                new NewUsers {UserHandle="CoffeeAddict",UserPass="000123",JoinDate= DateTime.Now.Date },
                new NewUsers {UserHandle="Ned",UserPass="123000",JoinDate= DateTime.Now.Date },
                new NewUsers {UserHandle="Prev",UserPass="010203",JoinDate= DateTime.Now.Date }
            );
        }
    }
}
