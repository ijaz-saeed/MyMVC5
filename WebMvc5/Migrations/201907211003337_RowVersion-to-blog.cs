namespace WebMvc5.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RowVersiontoblog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "RowVersion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "RowVersion");
        }
    }
}
