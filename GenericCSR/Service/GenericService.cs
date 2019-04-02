using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GenericCSR.Repository;
using GenericCSR.Sorter;
using PagedList;

namespace GenericCSR.Service
{
    public abstract class GenericService<TQueryDto,TCommandDto,TRepository, TEntity>
        : IGenericService<TQueryDto, TCommandDto>
        where TQueryDto : class
        where TCommandDto : class
        where TRepository : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected TRepository Repository { get; private set; }
        protected IMapper Mapper { get; private set; }

        protected GenericService(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public IEnumerable<TQueryDto> GetListOfDto(Pager pager, string filters, OrderByProperties orderByProperties)
        {
            var entities = GetListOfEntites(pager, filters, orderByProperties);
            var listOfDto = Mapper.Map<List<TEntity>, List<TQueryDto>>(entities.ToList());
            return listOfDto;
        }

        public virtual StaticPagedList<TQueryDto> GetJqGridData(Pager pager, string filters, OrderByProperties orderByProperties)
        {
            var entities = GetListOfEntites(pager, filters, orderByProperties);
            return Mapper.Map<IPagedList<TEntity>, StaticPagedList<TQueryDto>>((PagedList<TEntity>)entities);
        }

        public TQueryDto Find(int id)
        {
            var entity = Repository.Find(id);
            return entity == null ? null : Mapper.Map<TEntity, TQueryDto>(entity);
        }

        protected virtual IPagedList<TEntity> GetListOfEntites(Pager pager, string filters, OrderByProperties orderByProperties)
        {
            return Repository.Filter(pager, filters, orderByProperties);
        }

        public virtual void Create(TCommandDto dto)
        {
            ValidateDtoBeforeCreate(dto);
            ValidateDtoBeforeUpdateOrCreate(dto);

            var entity = Mapper.Map<TCommandDto, TEntity>(dto);

            Repository.Create(entity);
        }

        public virtual void ValidateDtoBeforeCreate(TCommandDto dto)
        {
           
        }

        public virtual void Update(TCommandDto dto)
        {
            ValidateDtoBeforeUpdate(dto);
            ValidateDtoBeforeUpdateOrCreate(dto);

            var entity = Mapper.Map<TCommandDto, TEntity>(dto);
            
            Repository.Update(entity);
        }

        public virtual void ValidateDtoBeforeUpdate(TCommandDto dto)
        {

        }

        public virtual void ValidateDtoBeforeUpdateOrCreate(TCommandDto dto)
        {

        }
        public virtual void Delete(int id)
        {
            Repository.Delete(id);
        }
        public virtual void ValidateDtoBeforeDelete(TCommandDto dto)
        {

        }
    }
}