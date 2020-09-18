namespace WebMvc5.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class BlogDescAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Description");
        }
    }
}
