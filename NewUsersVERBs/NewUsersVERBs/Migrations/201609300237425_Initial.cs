namespace NewUsersVERBs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserHandle = c.String(),
                        UserPass = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewUsers");
        }
    }
}
