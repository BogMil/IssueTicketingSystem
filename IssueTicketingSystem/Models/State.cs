using AutoMapper;
using GenericCSR;
using GenericCSR.Filter;
using GenericCSR.PropertyMapper;
using PagedList;
using System;
using System.Linq.Expressions;
using GenericCSR.Sorter;

namespace IssueTicketingSystem.Models
{
    public class State
    {
        public string Name { get; set; }
    }

    public class StateQueryDto : State
    {
        public int Id { get; set; }
    }

    public class StateCommandDto : State
    {
        public int id { get; set; }
    }

    public class StateViewModel : GenericJqGridViewModel<StateQueryDto> { }

    public class StateOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_state, StatePropertyMapper>
    {
        protected override Expression<Func<tbl_state, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class StateWherePredicateCreator : GenericWherePredicateCreator<tbl_state, StatePropertyMapper> { }

    public class StatePropertyMapper : GenericPropertyMapper<tbl_state, StateQueryDto>
    {
        public override Expression<Func<tbl_state, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class StateMappingProfile : Profile
    {
        public StateMappingProfile()
        {
            CreateMap<tbl_state, StateQueryDto>();

            CreateMap<StateCommandDto, tbl_state>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_region, o => o.Ignore());

            CreateMap<PagedList<tbl_state>, StaticPagedList<StateQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_state, StateQueryDto>>();
        }
    }
}