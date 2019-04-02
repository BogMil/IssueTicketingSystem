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
    public class PartType
    {
        public string Name { get; set; }
    }

    public class PartTypeQueryDto : PartType
    {
        public int Id { get; set; }
    }

    public class PartTypeCommandDto : PartType
    {
        public int id { get; set; }
    }

    public class PartTypeViewModel : GenericJqGridViewModel<PartTypeQueryDto> { }

    public class PartTypeOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_part_types, PartTypePropertyMapper>
    {
        protected override Expression<Func<tbl_part_types, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class PartTypeWherePredicateCreator : GenericWherePredicateCreator<tbl_part_types, PartTypePropertyMapper> { }

    public class PartTypePropertyMapper : GenericPropertyMapper<tbl_part_types, PartTypeQueryDto>
    {
        public override Expression<Func<tbl_part_types, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class PartTypeMappingProfile : Profile
    {
        public PartTypeMappingProfile()
        {
            CreateMap<tbl_part_types, PartTypeQueryDto>();

            CreateMap<PartTypeCommandDto, tbl_part_types>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_part, o => o.Ignore());

            CreateMap<PagedList<tbl_part_types>, StaticPagedList<PartTypeQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_part_types, PartTypeQueryDto>>();
        }
    }
}