namespace OAuthDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readwrite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demoes", "Read", c => c.Boolean(nullable: false));
            AddColumn("dbo.Demoes", "Write", c => c.Boolean(nullable: false));
            DropColumn("dbo.Demoes", "Scope");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demoes", "Scope", c => c.String());
            DropColumn("dbo.Demoes", "Write");
            DropColumn("dbo.Demoes", "Read");
        }
    }
}
