namespace Shop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updt1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderWares", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderWares", "Name");
        }
    }
}
