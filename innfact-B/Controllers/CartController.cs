using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innfact_B.Models;
using innfact_B.Service;
using innfact_B.ViewModels.In;
using innfact_B.ViewModels.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace innfact_B.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class CartController : ControllerBase
    {
        public CartService cartService;

        public CartController(InnfactContext db)
        {
            cartService = new CartService(db);
        }

        public IEnumerable<OutCartVM> GetCarts(Guid accountID)
        {
            return cartService.GetCart(accountID);
        }
        public void UpdateQuantity(InCartVM inCartVM)
        {
            cartService.UpdateQuantity(inCartVM);
        }
        public void DeleteCart(InCartVM inCartVM)
        {
            cartService.DeleteCart(inCartVM);
            
        }
        public void AddCart(InCartVM inCartVM)
        {
            cartService.AddCart(inCartVM);
        }
    }
}