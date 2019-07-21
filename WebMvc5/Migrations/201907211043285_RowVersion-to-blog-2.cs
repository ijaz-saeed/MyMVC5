namespace WebMvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RowVersiontoblog2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "RowVersion", null);
            AddColumn("dbo.Blogs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "RowVersion", c => c.DateTime(nullable: false));
        }
    }
}
