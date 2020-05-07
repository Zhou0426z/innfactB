using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innfact_B.Models;
using innfact_B.Service;
using innfact_B.ViewModels.In;
using innfact_B.ViewModels.Out;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace innfact_B.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private FavoriteService favoriteService;
        public FavoriteController(InnfactContext db)
        {
            favoriteService = new FavoriteService(db);
        }
        public void AddFavorite(InFavoriteVM inFavoriteVM)
        {
            favoriteService.AddFavorite(inFavoriteVM);
        }
        public IEnumerable<OutFavoriteVM> GetFavorite(Guid accountID)
        {
           return favoriteService.GetFavorite(accountID);
        }
        public void DeleteFavorite(Guid favoriteID)
        {
            favoriteService.DeleteFavorite(favoriteID);
        }
    }
}