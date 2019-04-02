//// ReSharper disable InconsistentNaming

//using System.Collections.Generic;
//using AutoMapper;

//namespace IssueTicketingSystem.Models.DTO
//{
//    public class AccountDTO
//    {
//        public int Id { get; set; }
//        public string Username { get; set; }
//        public string Password { get; set; }
//        public int IdJedinice { get; set; }
//        public string Ime { get; set; }
//        public string Prezime { get; set; }
//        public string Telefon { get; set; }
//        public string Mesto { get; set; }
//        public string Ramko { get; set; }

//        public List<string> Uloge { get; set; }
//    }

//    public class LoginAccountDto
//    {
//        public string Username;
//        public string Password;
//    }

//    public class AccountDtoMappingProfile : Profile
//    {
//        public AccountDtoMappingProfile()
//        {
//            CreateMap<A_NALOG, AccountDTO>()
//                .ForSourceMember(s => s.K_JEDINICA, o => o.Ignore())
//                .ForSourceMember(s => s.PasswordHash, o => o.Ignore())
//                .ForMember(d => d.IdJedinice, o => o.MapFrom(s => s.ID_Jedinice))
//                .ForMember(d => d.Id, o => o.MapFrom(s => s.ID_Naloga))
//                .ForMember(d => d.Username, o => o.Ignore())
//                .ForMember(d => d.Password, o => o.Ignore())
//                .ForMember(d => d.Mesto, o => o.Ignore())
//                .ForMember(d => d.Uloge, o => o.MapFrom(s => s.A_ULOGA_NALOGA.Select(x => x.A_ULOGA.NazivUloge).ToList()));
//        }
//    }
//}