namespace OAuthDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sonar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demoes", "RedirectMerchantUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demoes", "RedirectMerchantUrl");
        }
    }
}
