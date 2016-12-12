namespace UserODB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using UserODB.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UserODataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserODataContext context)
        {
            //context.UsersData.AddOrUpdate(U => U.Name, new UserOData { Name = "Salman" });
            //context.UsersData.AddOrUpdate(U => U.Password, new UserOData { Password = "12345" });

            //context.UsersData.AddOrUpdate(U => U.Name, new UserOData { Name = "Sherkhan" });
            //context.UsersData.AddOrUpdate(U => U.Password, new UserOData { Password = "a2b4c" });

            //context.UsersData.AddOrUpdate(U => U.Name, new UserOData { Name = "Mehwish" });
            //context.UsersData.AddOrUpdate(U => U.Password, new UserOData { Password = "1a3b5" });

            context.UsersData.AddOrUpdate(new UserOData[] 
            {
                new UserOData { Name="Salman", Password="12345" },
                new UserOData { Name="Sherkhan", Password="a2b4c" },
                new UserOData { Name="Mehwish", Password="1a3b5" }
            });
        }
    }
}
