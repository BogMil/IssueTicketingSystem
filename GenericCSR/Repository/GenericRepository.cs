using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GenericCSR.Filter;
using GenericCSR.Sorter;
using PagedList;

namespace GenericCSR.Repository
{
    public abstract class GenericRepository<TEntity, TContext, TOrderByPredicateCreator, TFilterPredicateCreator> : 
        IGenericRepository<TEntity> 
        where TEntity : class 
        where TContext: DbContext
        where TOrderByPredicateCreator : IOrderByPredicateCreator<TEntity>, new()
        where TFilterPredicateCreator : IWherePredicateCreator<TEntity>, new()
    {

        protected TContext Db { get; private set; }

        protected GenericRepository(TContext context)
        {
            Db = context;
        }

        public Expression<Func<TEntity, bool>> CustomWherePredicate { get; set; } = null;
        public TEntity Find(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual IPagedList<TEntity> Filter(Pager pager,string filters,OrderByProperties orderByProperties) 
        {
            var orderBy = new TOrderByPredicateCreator().GetPropertyObject(orderByProperties);
            var filterPredicate = new TFilterPredicateCreator().GetWherePredicate(filters);

            IQueryable<TEntity> listOfEntities = Db.Set<TEntity>();

            var listOfFilteredEntities = filterPredicate == null ? listOfEntities : listOfEntities.Where(filterPredicate);
            listOfFilteredEntities = ApplyCustomCondition(listOfFilteredEntities);

            if (CustomWherePredicate != null)
                listOfFilteredEntities = listOfFilteredEntities.Where(CustomWherePredicate);

            var listOfOrderedEntities = orderByProperties.OrderDirection == SortDirections.Ascending
                ? listOfFilteredEntities.OrderBy(orderBy.OrderByProperty)
                : listOfFilteredEntities.OrderByDescending(orderBy.OrderByProperty);

            var pagedList = Paged(listOfOrderedEntities, pager);
            return pagedList;
        }

        protected virtual IQueryable<TEntity> ApplyCustomCondition(IQueryable<TEntity> listOfFilteredEntities)
        {
            return listOfFilteredEntities;
        }

        protected IPagedList<TEntity> Paged(IEnumerable<TEntity> listOfEntities, Pager pager)
        {
            var paged = listOfEntities.ToPagedList(pager.CurrentPageNumber, pager.NumberOfRowsToDisplay);
            return paged;
        }

        public virtual void Create(TEntity entity)
        {
            entity = ModifyEntityBeforeCreate(entity);
            Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();
        }

        protected virtual TEntity ModifyEntityBeforeCreate(TEntity entity)
        {
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            var id = GetPrimaryKey(entity);
            var oldEntity = Db.Set<TEntity>().Find(id);
            entity = ModifyUpdateSourceEntityBeforeUpdate(entity, oldEntity);
            Db.Entry(oldEntity).CurrentValues.SetValues(entity);
            Db.SaveChanges();
        }

        protected virtual TEntity ModifyUpdateSourceEntityBeforeUpdate(TEntity updateSourceEntity, TEntity oldEntity)
        {
            return updateSourceEntity;
        }

        public virtual void Delete(int id)
        {
            var entity = Db.Set<TEntity>().Find(id);
            ShouldDeleteEntity(entity);
            Db.Set<TEntity>().Remove(entity ?? throw new Exception("Trazeni zapis za brisajne ne postoji u bazi"));
            Db.SaveChanges();
        }

        protected virtual void ShouldDeleteEntity(TEntity entity)
        {

        }

        protected virtual object GetPrimaryKey(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}