using Reimbursements.DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        int Count { get; }

        IQueryable<TEntity> All();

        TEntity GetById(object id);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);

        bool Contains(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);
    }
}
