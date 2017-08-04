namespace OAuthDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readwrite1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demoes", "CardNumber", c => c.String());
            AddColumn("dbo.Demoes", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demoes", "Zip");
            DropColumn("dbo.Demoes", "CardNumber");
        }
    }
}
