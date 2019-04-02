using PagedList;
using System;
using System.Linq.Expressions;
using GenericCSR.Sorter;

namespace GenericCSR.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //IEnumerable<TEntity> All(Pager pager);

        IPagedList<TEntity> Filter(Pager pager, string filters, OrderByProperties orderByProperties);

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        Expression<Func<TEntity, bool>> CustomWherePredicate { get; set; }

        TEntity Find(int id);
    }
}
