using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        //public BlogDbContext()
        //    : base("BlogDbContext")
        //{
        //    // Database.SetInitializer(new CreateDatabaseIfNotExists<BlogDbContext>());
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());
        //}
        
        public BlogDbContext(DbContextOptions<BlogDbContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] {
                    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                }));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
