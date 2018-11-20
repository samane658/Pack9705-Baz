namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rulesomepropertyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rules", "delayRate", c => c.Int(nullable: false));
            AddColumn("dbo.rules", "restLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.rules", "restLimit");
            DropColumn("dbo.rules", "delayRate");
        }
    }
}
