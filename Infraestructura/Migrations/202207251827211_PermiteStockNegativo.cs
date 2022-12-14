namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermiteStockNegativo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articulo", "PermiteStockNegativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articulo", "PermiteStockNegativo");
        }
    }
}
