namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataRegistro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Cidade = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.EstadoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Abreviacao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataRegistro = c.DateTime(precision: 7, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                        PrimeiroNome = c.String(),
                        UltimoNome = c.String(),
                        NomeDeUsuario = c.String(),
                        DataNascimento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Sexo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Senha",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataRegistro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Senha", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Endereco", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.Endereco", "EstadoID", "dbo.Estado");
            DropIndex("dbo.Senha", new[] { "UsuarioID" });
            DropIndex("dbo.Endereco", new[] { "UsuarioID" });
            DropIndex("dbo.Endereco", new[] { "EstadoID" });
            DropTable("dbo.Senha");
            DropTable("dbo.Usuario");
            DropTable("dbo.Estado");
            DropTable("dbo.Endereco");
        }
    }
}
