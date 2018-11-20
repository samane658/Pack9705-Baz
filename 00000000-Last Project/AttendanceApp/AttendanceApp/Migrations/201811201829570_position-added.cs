namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class positionadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        positionName = c.String(),
                        salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.positions");
        }
    }
}
