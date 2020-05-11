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

    public class OrderController : ControllerBase
    {
        private OrderService orderService;
        public OrderController(InnfactContext _db)
        {
            orderService = new OrderService(_db);
        }

        public void AddOrder(InOrderVM inOrderVM)
        {
            orderService.AddOrder(inOrderVM);
        }
        public IEnumerable<OutOrderVM> GetOrders(Guid accountID)
        {
            return orderService.GetOrders(accountID).OrderByDescending(x=>x.OrderDate);
        }
            
    }
}