using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Stackoverflow.Data.Dal.Repository.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> Table();
        ICollection<T> GetList(bool _IsDeleted = false);
        T Find(Expression<Func<T, bool>> match, bool _IsDeleted = false);
        ICollection<T> GetList(Expression<Func<T, bool>> match, bool _IsDeleted = false);
        void Add(T entity);
        void AddRange(List<T> entities);

        void Update(T updated);
        void UpdateRange(List<T> entities);

        void Delete(T entity);
        void DeleteRange(List<T> entities);

        ICollection<T> Filter(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null);
        int Save();
        bool IsSaved();
    }
}
