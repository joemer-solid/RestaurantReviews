using RestaurantReviewServiceRepository.Entities;
using RestaurantReviewsService.DomainModels;

namespace RestaurantReviewsService.ModelBuilders.DomainModelBuilders
{
    public sealed class UserReviewDomainModelBuilder : IModelBuilder<UserReviewDM, UserReview>
    {
        UserReviewDM IModelBuilder<UserReviewDM, UserReview>.Build(UserReview p)
        {
            return new UserReviewDM
            {
                Id = p.Id,
                Comments = p.Comments,
                RatingsDescription = p.RatingsDescription,
                RatingsLevel = p.RatingsLevel,
                RatingsRef = p.RatingsRef,
                RestaurantIdRef = p.RestaurantIdRef,
                Title = p.Title,
                UserIdRef = p.UserIdRef
            };
        }
    }
}