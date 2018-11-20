namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ruleadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        workingHour = c.Int(nullable: false),
                        startWorkTime = c.Int(nullable: false),
                        endWorkTime = c.Int(nullable: false),
                        overWorkRate = c.Int(nullable: false),
                        sendOutRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.rules");
        }
    }
}
