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
    public class PartStatus
    {
        public string Name { get; set; }
    }

    public class PartStatusQueryDto : PartStatus
    {
        public int Id { get; set; }
    }

    public class PartStatusCommandDto : PartStatus
    {
        public int id { get; set; }
    }

    public class PartStatusViewModel : GenericJqGridViewModel<PartStatusQueryDto> { }

    public class PartStatusOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_part_status, PartStatusPropertyMapper>
    {
        protected override Expression<Func<tbl_part_status, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class PartStatusWherePredicateCreator : GenericWherePredicateCreator<tbl_part_status, PartStatusPropertyMapper> { }

    public class PartStatusPropertyMapper : GenericPropertyMapper<tbl_part_status, PartStatusQueryDto>
    {
        public override Expression<Func<tbl_part_status, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class PartStatusMappingProfile : Profile
    {
        public PartStatusMappingProfile()
        {
            CreateMap<tbl_part_status, PartStatusQueryDto>();

            CreateMap<PartStatusCommandDto, tbl_part_status>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_replacement, o => o.Ignore());

            CreateMap<PagedList<tbl_part_status>, StaticPagedList<PartStatusQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_part_status, PartStatusQueryDto>>();
        }
    }
}