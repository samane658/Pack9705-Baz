namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        startTime = c.Int(nullable: false),
                        endTime = c.Int(nullable: false),
                        isCommited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.rests");
        }
    }
}
