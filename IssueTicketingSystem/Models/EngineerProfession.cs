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
    public class EngineerProfession
    {
        public int IdTypeOfComplain { get; set; }
        public int IdServiceEngineer { get; set; }
    }

    public class EngineerProfessionQueryDto : EngineerProfession
    {
        public int Id { get; set; }
        public string Profession { get; set; }
    }

    public class EngineerProfessionCommandDto : EngineerProfession
    {
        public int id { get; set; }
    }

    public class EngineerProfessionViewModel : GenericJqGridViewModel<EngineerProfessionQueryDto> { }

    public class EngineerProfessionOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_engineer_profession, EngineerProfessionPropertyMapper>
    {
        protected override Expression<Func<tbl_engineer_profession, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class EngineerProfessionWherePredicateCreator : GenericWherePredicateCreator<tbl_engineer_profession, EngineerProfessionPropertyMapper> { }

    public class EngineerProfessionPropertyMapper : GenericPropertyMapper<tbl_engineer_profession, EngineerProfessionQueryDto>
    {
        public override Expression<Func<tbl_engineer_profession, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdTypeOfComplain))
                return x => x.IdTypeOfComplain;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdServiceEngineer))
                return x => x.IdServiceEngineer;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class EngineerProfessionMappingProfile : Profile
    {
        public EngineerProfessionMappingProfile()
        {
            CreateMap<tbl_engineer_profession, EngineerProfessionQueryDto>()
                .ForMember(d=>d.Profession,o=>o.MapFrom(s=>s.tbl_type_of_complain.Profession));

            CreateMap<EngineerProfessionCommandDto, tbl_engineer_profession>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_service_engineer, o => o.Ignore())
                .ForMember(d => d.tbl_type_of_complain, o => o.Ignore());


            CreateMap<PagedList<tbl_engineer_profession>, StaticPagedList<EngineerProfessionQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_engineer_profession, EngineerProfessionQueryDto>>();
        }
    }
}