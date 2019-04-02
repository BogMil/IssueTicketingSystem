using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace GenericCSR
{
    public static class StaticJqGridViewModelFactory
    {
        public static GenericJqGridViewModel<TQueryDto> CreateJqGridViewModel<TQueryDto> (StaticPagedList<TQueryDto> listOfDto) 
            where TQueryDto : class ,new () 
        {
            var viewModel = new GenericJqGridViewModel<TQueryDto>()
            {
                Records = listOfDto.ToList(),
                CurrentPageNumber = listOfDto.PageNumber,
                TotalNumberOfPages = listOfDto.PageCount,
                TotalNumberOfRecords = listOfDto.TotalItemCount,
            };

            return viewModel;

        } 
    }
}
