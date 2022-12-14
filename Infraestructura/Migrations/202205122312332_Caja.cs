namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Caja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caja",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Efectivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaCorriente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Caja");
        }
    }
}
