using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsService.ViewModels;

namespace RestaurantReviewsService.PortServices
{
    public interface IRestaurantPortService
    {
        IList<RestaurantViewModel> GetAllRestaurants();

        IList<RestaurantViewModel> GetRestaurantReviewsByCity(string cityName);
    }
}

