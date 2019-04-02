using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IServiceEngineerService : IGenericService<ServiceEngineerQueryDto,ServiceEngineerCommandDto>
	{
	    string VendorSelectOptions();
	    StaticPagedList<EngineerProfessionQueryDto> ProfessionsOfEngineer(int id, Pager pager, OrderByProperties orderByProperties, string filters);
	    string ProfessionSelectOptions(int idServiceEngineer);
	}
}