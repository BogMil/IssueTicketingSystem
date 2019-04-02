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
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public bool Active { get; set; }
        public int IdCompany { get; set; }
    }

    public class AccountQueryDto : Account
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }

    }

    public class AccountCommandDto : Account
    {
        public int id { get; set; }
    }

    public class AccountViewModel : GenericJqGridViewModel<AccountQueryDto> { }

    public class AccountOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_account, AccountPropertyMapper>
    {
        protected override Expression<Func<tbl_account, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class AccountWherePredicateCreator : GenericWherePredicateCreator<tbl_account, AccountPropertyMapper> { }

    public class AccountPropertyMapper : GenericPropertyMapper<tbl_account, AccountQueryDto>
    {
        public override Expression<Func<tbl_account, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.FirstName))
                return x => x.FirstName;
            if (fieldName == GetDtoPropertyPathAsString(t => t.LastName))
                return x => x.LastName;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Email))
                return x => x.Email;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdRole))
                return x => x.IdRole;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdCompany))
                return x => x.IdCompany;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Company))
                return x => x.tbl_company.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Role))
                return x => x.tbl_roles.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class LoginAccountDto
    {
        public string Email;
        public string Password;
    }

    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<tbl_account, AccountQueryDto>()
                .ForMember(d => d.Company, o => o.MapFrom(s => s.tbl_company.Name))
                .ForMember(d => d.Role, o => o.MapFrom(s => s.tbl_roles.Name))
                .ForMember(d => d.Password, o => o.Ignore());

            CreateMap<AccountCommandDto, tbl_account>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_company, o => o.Ignore())
                .ForMember(d => d.tbl_roles, o => o.Ignore())
                .ForMember(d => d.tbl_complain, o => o.Ignore());

            CreateMap<PagedList<tbl_account>, StaticPagedList<AccountQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_account, AccountQueryDto>>();
        }
    }
}