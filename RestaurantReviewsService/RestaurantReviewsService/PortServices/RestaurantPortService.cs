using RestaurantReviewsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReviewsService.DataAdapters;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ModelBuilders;
using RestaurantReviewsService.ModelBuilders.ViewModelBuilders;

namespace RestaurantReviewsService.PortServices
{
    public class RestaurantPortService : IRestaurantPortService
    {
        private IRestaurantsDataAdapter _restaurantsDataAdapter;

        public RestaurantPortService()
        {
            _restaurantsDataAdapter = new RestaurantsDataAdapter();
        }

        public RestaurantPortService(IRestaurantsDataAdapter restaurantsDataAdapter)
        {
            _restaurantsDataAdapter = restaurantsDataAdapter;
        }

        public IList<RestaurantViewModel> GetAllRestaurants()
        {
            IModelBuilder<RestaurantViewModel, RestaurantDM> restaurantViewModelBuilder = null;
            IList<RestaurantViewModel> results = new List<RestaurantViewModel>();

            IList<RestaurantDM> restaurantDomainModelsList = _restaurantsDataAdapter.GetAllRestaurants();

            if(restaurantDomainModelsList != null)
            {
                restaurantViewModelBuilder = new RestaurantViewModelBuilder();

                foreach (RestaurantDM restaurantDM in restaurantDomainModelsList)
                {
                    results.Add(restaurantViewModelBuilder.Build(restaurantDM));

                }
            }

            return results;
            
        }
    }
}