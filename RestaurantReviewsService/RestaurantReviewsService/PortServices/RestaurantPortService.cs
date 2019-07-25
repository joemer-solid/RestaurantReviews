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
        private IUserReviewsDataAdapter _userReviewsDataAdapter;

        public RestaurantPortService()
        {
            _restaurantsDataAdapter = new RestaurantsDataAdapter();
            _userReviewsDataAdapter = new UserReviewsDataAdapter();
        }

        public RestaurantPortService(IRestaurantsDataAdapter restaurantsDataAdapter)
        {
            _restaurantsDataAdapter = restaurantsDataAdapter;
        }

        public IList<RestaurantViewModel> GetAllRestaurants()
        {
            IList<RestaurantViewModel> results = new List<RestaurantViewModel>();

            IList<RestaurantDM> restaurantDomainModelsList = _restaurantsDataAdapter.GetAllRestaurants();

            if(restaurantDomainModelsList != null)
            {
                IModelBuilder<RestaurantViewModel, RestaurantVMBuilderParams> restaurantViewModelBuilder = new RestaurantViewModelBuilder();

                foreach (RestaurantDM restaurantDM in restaurantDomainModelsList)
                {
                    results.Add(restaurantViewModelBuilder.Build(new RestaurantVMBuilderParams
                    {
                          RestaurantDomainModel = restaurantDM,
                          UserReviewsDMItems = null
                    }));

                }
            }

            return results;
            
        }

        public IList<RestaurantViewModel> GetRestaurantReviewsByCity(string cityName)
        {
            IList<RestaurantViewModel> results = new List<RestaurantViewModel>();

            IList<RestaurantDM> restaurantDomainModelsList = _restaurantsDataAdapter.GetRestaurantsByCity(cityName);

            if(restaurantDomainModelsList != null)
            {
                IModelBuilder<RestaurantViewModel, RestaurantVMBuilderParams> restaurantViewModelBuilder = new RestaurantViewModelBuilder();

                foreach (RestaurantDM restaurantDM in restaurantDomainModelsList)
                {
                    IList<UserReviewDM> usersReviewsDomainModelList = _userReviewsDataAdapter.GetUserReviewsForRestaurant(restaurantDM);

                    results.Add(restaurantViewModelBuilder.Build(new RestaurantVMBuilderParams
                    {
                         UserReviewsDMItems = usersReviewsDomainModelList,
                         RestaurantDomainModel = restaurantDM
                    }));
                }
            }

            return results;
        }
    }
}