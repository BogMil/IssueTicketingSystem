using System.Collections.Generic;
using AutoMapper;
using IssueTicketingSystem.AutoMapper;
using PagedList;
using Unity;
using Unity.Lifetime;

namespace IssueTicketingSystem
{
    public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, StaticPagedList<TDestination>>
    {
        private IMapper _mapper { get; set; }

        public PagedListConverter()
        {
            #region AutoMapperResolving
            var container = new UnityContainer();
            container.RegisterInstance(new AutoMapperConfiguration(), new SingletonLifetimeManager());
            var AutoMapperConfiguration = container.Resolve<AutoMapperConfiguration>();
            container.RegisterInstance(AutoMapperConfiguration.Configure().CreateMapper());
            _mapper = container.Resolve<IMapper>();
            #endregion
        }

        StaticPagedList<TDestination> ITypeConverter<PagedList<TSource>, StaticPagedList<TDestination>>.
            Convert(PagedList<TSource> source, StaticPagedList<TDestination> destination, ResolutionContext context)
        {
            var collection = _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
            return new StaticPagedList<TDestination>(collection, source.PageNumber, source.PageSize, source.TotalItemCount);
        }
    }
}