using RestaurantReviewServiceRepository.Entities;
using RestaurantReviewsService.DomainModels;

namespace RestaurantReviewsService.ModelBuilders.DataEntityModelBuilders
{
    public sealed class UserReviewDomainEntityModelBuilder : IModelBuilder<UserReview, UserReviewDM>
    {
        UserReview IModelBuilder<UserReview, UserReviewDM>.Build(UserReviewDM p)
        {
            return new UserReview
            {
                Comments = p.Comments,
                RatingsDescription = p.RatingsDescription,
                RatingsLevel = p.RatingsLevel,
                RatingsRef = p.RatingsRef,
                UserIdRef = p.UserIdRef,
                RestaurantIdRef = p.RestaurantIdRef
            };
        }
    }
}