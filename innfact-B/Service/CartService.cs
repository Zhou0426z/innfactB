using innfact_B.Models;
using innfact_B.ViewModels.In;
using innfact_B.ViewModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace innfact_B.Service
{
    public class CartService
    {
        private readonly InnfactContext db;
        public CartService(InnfactContext _db)
        {
            db = _db;
        }

        public IEnumerable<OutCartVM> GetCart(Guid accountID)
        {
            var result = from c in db.Carts.Where(x=>x.AccountId == accountID)
                         join p in db.Products
                         on c.ProductId equals p.ProductId
                         select new OutCartVM
                         {
                            CartID = c.CartId,
                            ImageUrl = p.Image.Where(x=>x.ForProductNo == p.ProductId).FirstOrDefault().ImageUrl,
                            Price = p.Price,
                            ProductName = p.ProductName,
                            Quantity = c.Quantity

                         };

            return result;
        }
        public void UpdateQuantity(InCartVM inCartVM)
        {
            db.Carts.Where(x => x.CartId == inCartVM.CartID).FirstOrDefault().Quantity = inCartVM.Quantity;
            db.SaveChanges();
        }
        public void DeleteCart(InCartVM inCartVM)
        {
            var value = db.Carts.Where(x => x.CartId == inCartVM.CartID).FirstOrDefault();
            db.Carts.Remove(value);
            db.SaveChanges();
           
        }
        public void AddCart(InCartVM inCartVM)
        {
            var stock = db.Products.FirstOrDefault(x => x.ProductId == inCartVM.ProductID).Stock;
            var valueCart = db.Carts.FirstOrDefault(x => x.AccountId == inCartVM.AccountID && x.ProductId == inCartVM.ProductID);
            if (valueCart != null)
            {
                valueCart.Quantity += inCartVM.Quantity;
                if (valueCart.Quantity>stock)
                {
                    valueCart.Quantity = stock;
                }
                db.SaveChanges();
                return;
            }

            var value = new Carts()
            {
                AccountId = inCartVM.AccountID,
                CartId = Guid.NewGuid(),
                ProductId = inCartVM.ProductID,
                Quantity = inCartVM.Quantity
            };
            db.Carts.Add(value);
            db.SaveChanges();
        }
    }
}
