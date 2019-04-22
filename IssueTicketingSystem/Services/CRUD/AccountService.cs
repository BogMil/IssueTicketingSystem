using System;
using System.Net;
using System.Net.Mail;
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

	    public override void Create(AccountCommandDto dto)
	    {
            var entity = new tbl_account();
	        Mapper.Map(dto, entity);
	        entity = Repository.CreateAndReturn(entity);

	        //var body = "Username: {0}, Password: {1}";
	        //var message = new MailMessage();
	        //message.To.Add(new MailAddress("milanbogdanovic11@hotmail.com"));  // replace with valid value 
	        //message.From = new MailAddress("");  // replace with valid value
	        //message.Subject = "Your email subject";
	        //message.Body = string.Format(body, entity.Email, entity.Password);
	        //message.IsBodyHtml = true;

	        //using (var smtp = new SmtpClient())
	        //{
	        //    var credential = new NetworkCredential
	        //    {
	        //        UserName = "",  // replace with valid value
	        //        Password = ""  // replace with valid value
	        //    };
	        //    //smtp.UseDefaultCredentials = false;
	        //    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
         //       smtp.Credentials = credential;
	        //    smtp.Host = "smtp.gmail.com";
	        //    smtp.Port = 587;
	        //    smtp.EnableSsl = true;
	        //    smtp.Send(message);
	        //}
        }
	}
}