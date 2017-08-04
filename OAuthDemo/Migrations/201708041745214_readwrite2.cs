namespace OAuthDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readwrite2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demoes", "ExpirationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Demoes", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demoes", "Zip", c => c.String());
            DropColumn("dbo.Demoes", "ExpirationDate");
        }
    }
}
