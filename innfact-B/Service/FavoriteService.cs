using innfact_B.Models;
using innfact_B.ViewModels.In;
using innfact_B.ViewModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.Service
{
    
    public class FavoriteService

    {
        private readonly InnfactContext db;
        public FavoriteService(InnfactContext _db)
        {
            db = _db;
        }
        public void AddFavorite(InFavoriteVM inFavoriteVM)
        {
            if(db.Favorite.FirstOrDefault(x=>x.AccountId == inFavoriteVM.AccountID && x.ProductId == inFavoriteVM.ProductID)!=null)
            {
                return;
            }
            var value = new Favorite()
            {
                AccountId = inFavoriteVM.AccountID,
                FavoriteId = Guid.NewGuid(),
                ProductId = inFavoriteVM.ProductID
            };
            db.Favorite.Add(value);
            db.SaveChanges();
        }

        public IEnumerable<OutFavoriteVM> GetFavorite(Guid accountID)
        {
            var result = from f in db.Favorite.Where(x => x.AccountId == accountID)
                        join p in db.Products
                        on f.ProductId equals p.ProductId
                        select new OutFavoriteVM
                        {
                            favoriteID = f.FavoriteId,
                            productID = p.ProductId,
                            productName = p.ProductName,
                            unitPrice = p.Price,
                            imgUrl = db.Image.Where(x => x.ForProductNo == p.ProductId).FirstOrDefault().ImageUrl
                        };

            return result;
        }
        public void DeleteFavorite(Guid favoriteID)
        {
            var value = db.Favorite.Where(x => x.FavoriteId == favoriteID).FirstOrDefault();
            db.Remove(value);
            db.SaveChanges();
        }
    }
}
