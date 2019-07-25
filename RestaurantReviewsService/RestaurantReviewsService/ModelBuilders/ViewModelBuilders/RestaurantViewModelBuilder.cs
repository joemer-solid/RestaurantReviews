using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ViewModels;

namespace RestaurantReviewsService.ModelBuilders.ViewModelBuilders
{
    public sealed class RestaurantViewModelBuilder : IModelBuilder<RestaurantViewModel, RestaurantDM>
    {
        RestaurantViewModel IModelBuilder<RestaurantViewModel, RestaurantDM>.Build(RestaurantDM p)
        {
            // TODO - change p to a struct containing possibly restaurant reviews
            return new RestaurantViewModel
            {
                City = p.City,
                Id = p.Id,
                Name = p.Name,
                Overview = p.Overview,
                State = p.State,
                StateId = p.StateId,
                StreetAddress = p.StreetAddress
            };
        }
    }
}