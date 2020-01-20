namespace Shop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Orders",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Date = c.DateTime(nullable: false),
            //            Wares = c.String(),
            //            User1 = c.String(),
            //            Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderWares",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        WareId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Wares", t => t.WareId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.UserId)
                .Index(t => t.WareId);
            
            //CreateTable(
            //    "dbo.Users",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            SecondName = c.String(),
            //            LastName = c.String(),
            //            Login = c.String(),
            //            Password = c.String(),
            //            RoleId = c.Int(nullable: false),
            //            Position = c.String(),
            //            ImageData = c.Binary(),
            //            ImageMimeType = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.Roles",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Wares",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Description = c.String(nullable: false),
            //            Category = c.String(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ImageData = c.Binary(),
            //            ImageMimeType = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderWares", "WareId", "dbo.Wares");
            DropForeignKey("dbo.OrderWares", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.OrderWares", "OrderId", "dbo.Orders");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.OrderWares", new[] { "WareId" });
            DropIndex("dbo.OrderWares", new[] { "UserId" });
            DropIndex("dbo.OrderWares", new[] { "OrderId" });
            DropTable("dbo.Wares");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.OrderWares");
            DropTable("dbo.Orders");
        }
    }
}
