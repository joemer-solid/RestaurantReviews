using RestaurantReviewServiceRepository.Entities;
using RestaurantReviewsService.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantReviewsService.ModelBuilders.DataEntityModelBuilders
{
    public sealed class RestaurantDomainEntityModelBuilder : IModelBuilder<Restaurant, RestaurantDM>
    {
        Restaurant IModelBuilder<Restaurant, RestaurantDM>.Build(RestaurantDM p)
        {
            return new Restaurant
            {
                City = p.City,
                Name = p.Name,
                Overview = p.Overview,
                StateIdRef = p.StateId,
                StreetAddress = p.StreetAddress
            };
        }
    }
}