namespace OAuthDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demoes", "TransactionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demoes", "TransactionId");
        }
    }
}
