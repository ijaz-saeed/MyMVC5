using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebMvc5.DAL.IRepository;
using WebMvc5.Models;

namespace WebMvc5.DAL
{
    public class BlogRepository : GenericRepository<BlogDbContext, Blog>, IBlogRepository
    {
        public BlogRepository()
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
    }
}