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
    public class Unit
    {
        public string Name { get; set; }
    }

    public class UnitQueryDto : Unit
    {
        public int Id { get; set; }
    }

    public class UnitCommandDto : Unit
    {
        public int id { get; set; }
    }

    public class UnitViewModel : GenericJqGridViewModel<UnitQueryDto> { }

    public class UnitOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_unit, UnitPropertyMapper>
    {
        protected override Expression<Func<tbl_unit, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class UnitWherePredicateCreator : GenericWherePredicateCreator<tbl_unit, UnitPropertyMapper> { }

    public class UnitPropertyMapper : GenericPropertyMapper<tbl_unit, UnitQueryDto>
    {
        public override Expression<Func<tbl_unit, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class UnitMappingProfile : Profile
    {
        public UnitMappingProfile()
        {
            CreateMap<tbl_unit, UnitQueryDto>();

            CreateMap<UnitCommandDto, tbl_unit>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_part, o => o.Ignore());

            CreateMap<PagedList<tbl_unit>, StaticPagedList<UnitQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_unit, UnitQueryDto>>();
        }
    }
}