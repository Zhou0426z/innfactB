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
namespace innfact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountService accountService;
        public AccountController(InnfactContext db)
        {
            accountService = new AccountService(db);
        }
        [HttpPost]
        public OutAccountVM SignUp(InAccountVM inAccountVM)
        {
           return accountService.SignUp(inAccountVM);
        }
        [HttpPost]
        public OutAccountVM Login(InAccountVM inAccountVM)
        {
           return accountService.Login(inAccountVM);
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