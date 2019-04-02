using System;
using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class AccountService : GenericService<AccountQueryDto,AccountCommandDto,IAccountRepository,tbl_account>,IAccountService
	{
		public AccountService(IAccountRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public AccountQueryDto GetAccountForCredentials(string email, string password)
	    {
	        var account = Repository.GetAccountForCredentials(email,password);
	        return account == null ? null : Mapper.Map<tbl_account,AccountQueryDto>(account);
	    }
	}
}