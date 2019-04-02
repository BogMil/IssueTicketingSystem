//using System.Collections.Generic;
//using ExpressionBuilder.Generics;
//using Pokret.Models;

//namespace Pokret.Services.CRUD.Interfaces
//{
//    public interface IGenericService<TViewModel, TQueryDto, TCommandDto, TEntity> where TEntity : class
//    {
//        //void Create(TCommandDto dto);
//        //void Delete(int id);
//        //TQueryDto GetDto(int id);   
//        IEnumerable<TQueryDto> GetListOfDto(Pager pager, Filter<TEntity> filterPredicate, IOrderByProperties<TEntity> orderByProperties);
//        TViewModel GetJqGridViewModel(Pager pager, Filter<TEntity> filterPredicate, IOrderByProperties<TEntity> orderByProperties);

//        //void Update(TCommandDto dto);
//        //void Dispose();
//    }
//}