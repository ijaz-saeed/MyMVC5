using ApplicationCore.Entities;
using ApplicationCore.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Blog GetById(int id);
        Task<Blog> GetByIdAsync(int id);

        Task<PaginatedList<Blog>> ToPaginatedListAsync(IQueryable<Blog> source, int pageIndex, int pageSize);
    }
}
