using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Stackoverflow.Data.Dal.Repository.Abstract;

namespace Stackoverflow.Data.Dal.Repository.Concrete
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EfContext _context;
        private bool disposed = false;
        public Repository(EfContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            //return Save() > 0 ? true : false;
        }

        public void AddRange(List<T> entities)
        {
            _context.AddRange(entities);
            //return Save() > 0 ? true : false;
        }

        public void Delete(T entity)
        {

            _context.Attach(entity);
          
            _context.Remove(entity);
            _context.SaveChanges();
            //return Save();
        }

        public void DeleteRange(List<T> entities)
        {
            _context.RemoveRange(entities);
            //return Save();
        }

        public ICollection<T> Filter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return query.ToList();
        }

        public T Find(Expression<Func<T, bool>> match, bool _IsDeleted = false)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }


        public ICollection<T> GetList(bool _IsDeleted = false)
        {
            return _context.Set<T>()
                .ToList();
        }

        public ICollection<T> GetList(Expression<Func<T, bool>> match, bool _IsDeleted = false)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public IQueryable<T> Table()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Update(T updated)
        {
            _context.Update(updated);
            //return Save() > 0 ? true : false;
        }

        public void UpdateRange(List<T> entities)
        {
            _context.Update(entities);
            //return Save() > 0 ? true : false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsSaved()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
