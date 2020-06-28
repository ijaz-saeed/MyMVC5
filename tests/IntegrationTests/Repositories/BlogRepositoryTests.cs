using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTests.Repositories
{
    [TestClass]

    public class BlogRepositoryTests
    {
        private readonly BlogDbContext _dbContext;
        private readonly BlogRepository _blogRepository;

        public BlogRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<BlogDbContext>()
               .UseInMemoryDatabase(databaseName: "TestCatalog")
               .Options;

            _dbContext = new BlogDbContext(dbOptions);
            _blogRepository = new BlogRepository(_dbContext);
        }

        [TestMethod]
        public void Blog_GetAll()
        {
            var blog = new Blog
            {
                Description = "test desc",
                Url = "www.google.com"
            };

            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();

            Assert.IsTrue(_blogRepository.GetAll().ToList().Count > 0);
        }
    }
}
