using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMvc5.Models;

namespace WebMvc5.DAL.IRepository
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Blog GetById(int id);
        Task<Blog> GetByIdAsync(int id);
    }
}
