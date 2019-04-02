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
    public class TypeOfComplain
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public bool Active { get; set; }
    }

    public class TypeOfComplainQueryDto : TypeOfComplain
    {
        public int Id { get; set; }
    }

    public class TypeOfComplainCommandDto : TypeOfComplain
    {
        public int id { get; set; }
    }

    public class TypeOfComplainViewModel : GenericJqGridViewModel<TypeOfComplainQueryDto> { }

    public class TypeOfComplainOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_type_of_complain, TypeOfComplainPropertyMapper>
    {
        protected override Expression<Func<tbl_type_of_complain, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class TypeOfComplainWherePredicateCreator : GenericWherePredicateCreator<tbl_type_of_complain, TypeOfComplainPropertyMapper> { }

    public class TypeOfComplainPropertyMapper : GenericPropertyMapper<tbl_type_of_complain, TypeOfComplainQueryDto>
    {
        public override Expression<Func<tbl_type_of_complain, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Profession))
                return x => x.Profession;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class TypeOfComplainMappingProfile : Profile
    {
        public TypeOfComplainMappingProfile()
        {
            CreateMap<tbl_type_of_complain, TypeOfComplainQueryDto>();

            CreateMap<TypeOfComplainCommandDto, tbl_type_of_complain>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_complain, o => o.Ignore())
                .ForMember(d => d.tbl_engineer_profession, o => o.Ignore());

            CreateMap<PagedList<tbl_type_of_complain>, StaticPagedList<TypeOfComplainQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_type_of_complain, TypeOfComplainQueryDto>>();
        }
    }
}