using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IGenericRepository<T> where T : class
    {
        public EfRepository(BlogDbContext dbContext)
        {
            _entities = dbContext;
        }
        protected readonly BlogDbContext _entities;
        public BlogDbContext Context
        {

            get { return _entities; }
            //set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>().AsNoTracking();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            int x = await _entities.SaveChangesAsync();

            return x;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
