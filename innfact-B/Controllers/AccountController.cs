using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using innfact_B.Models;
using innfact_B.Service;
using innfact_B.ViewModels.In;
using innfact_B.ViewModels.Out;
using Microsoft.AspNetCore.Authorization;
using innfact_B.Helper;
using Microsoft.AspNetCore.Cors;

namespace innfact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private AccountService accountService;
        private JwtHelper jwtHelper;
        public AccountController(InnfactContext db,JwtHelper _jwtHelper)
        {
            accountService = new AccountService(db);
            jwtHelper = _jwtHelper;
        }
        [AllowAnonymous]
       public OutAccountVM SignUp(InAccountVM inAccountVM)
        {
           return accountService.SignUp(inAccountVM);
        }
        [AllowAnonymous]
        public OutAccountVM LineSignUp(string token)
        {
            return accountService.LineSignUp(token,jwtHelper);
        }

        [AllowAnonymous]

        public OutAccountVM Login(InAccountVM inAccountVM)
        {
            return accountService.Login(inAccountVM,jwtHelper);
        }
        [AllowAnonymous]

        public OutAccountVM LineLogin(string token)
        {
            return accountService.LineLogin(token, jwtHelper);
        }
        public bool UpdatePassword(InPasswordVM inPasswordVM)
        {
           return accountService.UpdatePassword(inPasswordVM);
        }

        public OutAccountVM GetAccount(Guid accountID)
        {
            return accountService.GetAccount(accountID);
        }
        public void UpadateAccount(InAccountVM inAccountVM)
        {
            accountService.UpdateAccount(inAccountVM);
        }
    }
}