using ApplicationCore.Entities;
using ApplicationCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBlogService
    {
        IQueryable<Blog> GetAll();
        Task<Blog> GetByIdAsync(int id);
        void Edit(Blog entity);
        void Delete(Blog entity);

        void Save();
        Task<int> SaveAsync();
        Task<PaginatedList<Blog>> ToPaginatedListAsync(IQueryable<Blog> source, int pageIndex, int pageSize);

    }
}
