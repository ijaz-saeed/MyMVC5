using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    //public class BlogRepository : GenericRepository<BlogDbContext, Blog>, IBlogRepository
    public class BlogRepository : EfRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext dbContext) : base(dbContext)
        {

        }

        public Blog GetById(int id)
        {
            var query = Context.Blogs.Find(id);
            return query;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var query = await Context.Blogs.FindAsync(id);
            return query;
        }

        public async Task<PaginatedList<Blog>> ToPaginatedListAsync(IQueryable<Blog> source, int pageIndex, int pageSize)
        {
            return await PaginatedList<Blog>.CreateAsync(source, pageIndex, pageSize);
        }
    }

}
