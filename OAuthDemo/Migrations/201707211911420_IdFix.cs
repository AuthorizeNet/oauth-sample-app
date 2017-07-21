namespace OAuthDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demoes", "ClientId", c => c.String());
            AddColumn("dbo.Demoes", "ClientSecret", c => c.String());
            DropColumn("dbo.Demoes", "Secret");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demoes", "Secret", c => c.String());
            DropColumn("dbo.Demoes", "ClientSecret");
            DropColumn("dbo.Demoes", "ClientId");
        }
    }
}
