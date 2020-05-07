using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innfact_B.Models;
using innfact_B.ViewModels.In;
using innfact.Helper;
using innfact_B.ViewModels.Out;
using Microsoft.AspNetCore.Http;

namespace innfact_B.Service
{
    public class AccountService
    {
        private readonly InnfactContext db;
        public AccountService(InnfactContext _db)
        {
            db = _db;
        }
        public OutAccountVM SignUp(InAccountVM account)
        {
            var hasBeenSignUp = db.Accounts.SingleOrDefault(x => x.Email == account.Email && x.LoginBy == account.LoginBy);
            var result = new OutAccountVM();
            if(hasBeenSignUp!=null)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
            var value = new Accounts()
            {
                AccountId = Guid.NewGuid(),
                BirthDay = account.BirthDay,
                Email = account.Email,
                LoginBy = account.LoginBy,
                Password = AccountHelper.EncodePassword(account.Password) ?? "",
                RoleId = db.Roles.FirstOrDefault(x => x.RoleName == "一般使用者").RoleId,
                UserName = account.UserName
            };
            db.Accounts.Add(value);
            db.SaveChanges();
            result.StatusCode = StatusCodes.Status200OK;
            result.AccountID = value.AccountId;
            return result;
        }
        public OutAccountVM Login(InAccountVM account)
        {
            var result = new OutAccountVM();
            var value = db.Accounts.Where(x => x.LoginBy == account.LoginBy)
                                   .SingleOrDefault(x => x.Email == account.Email && x.Password == AccountHelper.EncodePassword(account.Password));
            if(value!=null)
            {
                result.StatusCode = StatusCodes.Status200OK;
                result.AccountID = value.AccountId;
                result.Email = value.Email;
                result.Name = value.UserName;
               
            }
            else
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
            }


            return result;
            
        }
        public bool UpdatePassword(InPasswordVM inPasswordVM)
        {
            var valueAccount = db.Accounts.Where(x => x.AccountId == inPasswordVM.AccountID).FirstOrDefault();

            if (AccountHelper.EncodePassword(inPasswordVM.OldPassword) == valueAccount.Password)
            {
                valueAccount.Password = AccountHelper.EncodePassword(inPasswordVM.NewPassword);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public OutAccountVM GetAccount(Guid accountID)
        {
            var result = from a in db.Accounts.Where(x => x.AccountId == accountID)
                         select new OutAccountVM
                         {
                             BirthDay = a.BirthDay,
                             Email = a.Email,
                             Subscribe = a.Subscribe,
                             Name = a.UserName,
                             Gender = a.Gender,
                             Phone = a.Phone,
                         };
            return result.FirstOrDefault();
            
        }
        public void UpdateAccount(InAccountVM inAccountVM)
        {
            var value = db.Accounts.FirstOrDefault(x => x.AccountId == inAccountVM.AccountID);
            value.UserName = inAccountVM.UserName;
            value.Phone = inAccountVM.Phone;
            value.BirthDay = inAccountVM.BirthDay;
            value.Gender = inAccountVM.Gender;
            value.Subscribe = inAccountVM.Subscribe;
            db.SaveChanges();

        }
    }
}
