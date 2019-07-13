using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMvc5.Migrations;

namespace WebMvc5.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("BlogDbContext")
        {
           // Database.SetInitializer(new CreateDatabaseIfNotExists<BlogDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

}