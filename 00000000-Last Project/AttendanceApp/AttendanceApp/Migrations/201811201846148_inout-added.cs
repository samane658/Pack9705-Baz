namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inoutadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.inouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        personId = c.Int(nullable: false),
                        startTime = c.Int(nullable: false),
                        endTime = c.Int(nullable: false),
                        isRest = c.Boolean(nullable: false),
                        workInThisDay = c.Int(nullable: false),
                        delayInThisDay = c.Int(nullable: false),
                        isCommited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.inouts");
        }
    }
}
