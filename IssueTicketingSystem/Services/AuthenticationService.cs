using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace IssueTicketingSystem.Services
{
    public class AuthenticationService
    {
        private readonly IAccountService _accountService;
        public AuthenticationService(IAccountService accountService)
        {
            _accountService = accountService;
        }
        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        public void Authenticate(string username, string password)
        {
            var account = _accountService.GetAccountForCredentials(username, password);
            if (account == null)
                throw new Exception("Wrong Credentials");
            var claims = GetAccountClaims(account);

            SignIn(claims);
        }

        private void SignIn(IEnumerable<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = false,
            };

            AuthenticationManager.SignIn(properties, identity);
        }

        private IEnumerable<Claim> GetAccountClaims(AccountQueryDto account)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{account.FirstName} {account.LastName}"),
                new Claim(CustomClaimTypes.IdCompany, account.IdCompany.ToString()),
                new Claim(CustomClaimTypes.IdAccount, account.Id.ToString()),
                new Claim(CustomClaimTypes.IdRole, account.IdRole.ToString()),
                new Claim(ClaimTypes.Role, account.Role)
            };

            return claims;
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut();
        }
    }
}