using RestaurantReviewServiceRepository.Entities;
using RestaurantReviewServiceRepository.Operations;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ModelBuilders;
using RestaurantReviewsService.ModelBuilders.DomainModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantReviewsService.DataAdapters
{
    public sealed class RestaurantsDataAdapter : IRestaurantsDataAdapter
    {
      
        IList<RestaurantDM> IRestaurantsDataAdapter.GetAllRestaurants()
        {
            IModelBuilder<RestaurantDM, Restaurant> modelBuilder = new RestaurantDomainModelBuilder();
            SelectAllRestaurantsOperation selectAllRestaurantsOperaton = new SelectAllRestaurantsOperation();
            IList<RestaurantDM> results = new List<RestaurantDM>();

            IList<Restaurant> operationResults = selectAllRestaurantsOperaton.SelectAll();

            if (operationResults != null && operationResults.Count > 0)
            {
                foreach (Restaurant restaurant in operationResults)
                {
                    results.Add(modelBuilder.Build(restaurant));
                }
            }

            return results;
        }

        IList<RestaurantDM> IRestaurantsDataAdapter.GetRestaurantsByCity(string cityName)
        {
            IList<RestaurantDM> results = new List<RestaurantDM>();

            var filteredResults = ((IRestaurantsDataAdapter)this).GetAllRestaurants().Where(x => x.City == cityName).ToList<RestaurantDM>();

            if(filteredResults != null && filteredResults.Count > 0)
            {
                results = filteredResults.ToList<RestaurantDM>();
            }

            return results;
        }
    }
}