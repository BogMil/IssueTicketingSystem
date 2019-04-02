using GenericCSR.Filter;
using GenericCSR.Repository;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories
{
    public abstract class IssueTicketingSystemRepository<TEntity, TOrderByPredicateCreator, TWherePredicateCreator>
        : GenericRepository<TEntity, IssueTicketingSystemEntities, TOrderByPredicateCreator, TWherePredicateCreator>
        where TEntity : class
        where TOrderByPredicateCreator : IOrderByPredicateCreator<TEntity>, new()
        where TWherePredicateCreator : IWherePredicateCreator<TEntity>, new()
    {
        protected IssueTicketingSystemRepository(IssueTicketingSystemEntities context) : base(context){}
    }
}