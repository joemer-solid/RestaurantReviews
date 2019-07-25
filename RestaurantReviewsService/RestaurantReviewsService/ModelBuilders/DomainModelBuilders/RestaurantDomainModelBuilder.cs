using RestaurantReviewService.Entities;
using RestaurantReviewsService.DomainModels;

namespace RestaurantReviewsService.ModelBuilders.DomainModelBuilders
{
    public sealed class RestaurantDomainModelBuilder : IModelBuilder<RestaurantDM, Restaurant>
    {
        RestaurantDM IModelBuilder<RestaurantDM, Restaurant>.Build(Restaurant p)
        {
            return new RestaurantDM
            {
                City = p.City,
                Id = p.Id,
                Name = p.Name,
                Overview = p.Overview,
                State = p.State,
                StateId = p.StateIdRef,
                StreetAddress = p.StreetAddress
            };
        }
    }
}