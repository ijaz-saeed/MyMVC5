using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void Add(Blog entity)
        {
            _blogRepository.Add(entity);
        }


        public void Edit(Blog entity)
        {
            _blogRepository.Edit(entity);
        }

        public IQueryable<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            Blog query = await _blogRepository.GetByIdAsync(id);
            return query;
        }

        public void Save()
        {
            _blogRepository.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _blogRepository.SaveAsync();
        }

        public void Delete(Blog blog)
        {
            _blogRepository.Delete(blog);
        }

        public async Task<PaginatedList<Blog>> ToPaginatedListAsync(IQueryable<Blog> source, int pageIndex, int pageSize)
        {
            return await _blogRepository.ToPaginatedListAsync(source, pageIndex, pageSize);
        }
    }
}
