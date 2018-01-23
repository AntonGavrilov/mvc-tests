namespace JQueryUI_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computers", "Model", c => c.String(nullable: false, maxLength: 20, defaultValue: "123"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Computers", "Model", c => c.String());
        }
    }
}
