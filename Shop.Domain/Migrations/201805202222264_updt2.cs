namespace Shop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updt2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderWares", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderWares", "Name", c => c.String());
        }
    }
}
