using innfact_B.Models;
using innfact_B.ViewModels.In;
using innfact_B.ViewModels.Out;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.Service
{
    public class OrderService
    {
        private readonly InnfactContext db;
        public OrderService(InnfactContext _db)
        {
            db = _db;
        }
        public void AddOrder(InOrderVM inOrderVM)
        {
            var orderDetails = new List<OrderDetails>();
            var valueCart = db.Carts.Where(x => x.AccountId == inOrderVM.AccountId).ToList();
            for (var i = 0; i<valueCart.Count();i++)
            {
                var orderDetail = new OrderDetails()
                {
                    OrderDetailId = Guid.NewGuid(),
                    ProductId = valueCart[i].ProductId,
                    UnitPrice = db.Products.Where(x => x.ProductId == valueCart[i].ProductId).FirstOrDefault().Price,
                    Quantity = valueCart[i].Quantity,
                    Discount = 0
                    
                };
                db.Products.FirstOrDefault(x => x.ProductId == valueCart[i].ProductId).Stock -= valueCart[i].Quantity;
                orderDetails.Add(orderDetail);
            }
            var value = new Orders()
            {
                OrderId = Guid.NewGuid(),
                AccountId = inOrderVM.AccountId, 
                OrderDate = DateTime.Today,
                ShipVia = inOrderVM.ShipVia,
                Freight = inOrderVM.Freight,
                ShipCity = inOrderVM.ShipCity,
                ShipAddress = inOrderVM.ShipAddress,
                PayWay = inOrderVM.PayWay,
                HasPay = inOrderVM.HasPay,
                CustomerName = inOrderVM.CustomerName,
                Phone = inOrderVM.Phone,
                InvoiceWay = inOrderVM.InvoiceWay,
                Remark = inOrderVM.Remark,
                OrderDetails = orderDetails
                
            };
            db.Orders.Add(value);
            db.Carts.RemoveRange(valueCart);
            db.SaveChanges();

        }

        public IEnumerable<OutOrderVM> GetOrders(Guid accountID)
        {
            var result = new List<OutOrderVM>();

            var valueOrder = db.Orders.Where(x => x.AccountId == accountID).ToList();

            for(var i = 0; i<valueOrder.Count();i++)
            {
                var orderDetails = new List<OutOrderDetailVM>();
                var orderDetail = from od in db.OrderDetails.Where(x => x.OrderId == valueOrder[i].OrderId)
                                  join p in db.Products
                                  on od.ProductId equals p.ProductId
                                  select new OutOrderDetailVM
                                  {
                                      ProductId = p.ProductId,
                                      ProductName = p.ProductName,
                                      Quantity = od.Quantity,
                                      UnitPrice = od.UnitPrice
                                  };

                for (var j=0;j< orderDetail.Count();j++)
                {
                    orderDetails.Add(orderDetail.ToList()[j]);

                };
                var value = new OutOrderVM()
                {
                    OrderID = valueOrder[i].OrderId,
                    ShipAddress = valueOrder[i].ShipAddress,
                    OrderDate = valueOrder[i].OrderDate,
                    TotalPrice = db.OrderDetails.Where(x=>x.OrderId == valueOrder[i].OrderId).GroupBy(x => x.OrderId).Select(group => group.Sum(item => item.UnitPrice * item.Quantity)).FirstOrDefault(),
                    HasPay = false,
                    OrderDetails = orderDetails

                };
                result.Add(value);
            }
            return result;
        }
    }
}
