namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colunas_add_estado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estado", "DataRegistro", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Estado", "Ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estado", "Ativo");
            DropColumn("dbo.Estado", "DataRegistro");
        }
    }
}
