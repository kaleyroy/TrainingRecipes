namespace EF5Repository.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Name", c => c.String());
            DropColumn("dbo.Customer", "CompanyName");
            DropColumn("dbo.Customer", "ContactName");
            DropColumn("dbo.Customer", "ContactTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "ContactTitle", c => c.String());
            AddColumn("dbo.Customer", "ContactName", c => c.String());
            AddColumn("dbo.Customer", "CompanyName", c => c.String());
            DropColumn("dbo.Customer", "Name");
        }
    }
}
