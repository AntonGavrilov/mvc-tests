namespace JQueryUI_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            AlterColumn("dbo.Computers", "Model", c => c.String(nullable: false, maxLength: 20, defaultValue: "123"));

        }
        
        public override void Down()
        {
            DropTable("dbo.Computers");
        }
    }
}
