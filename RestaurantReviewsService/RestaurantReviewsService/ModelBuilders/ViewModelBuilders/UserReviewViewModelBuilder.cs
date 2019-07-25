using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ViewModels;

namespace RestaurantReviewsService.ModelBuilders.ViewModelBuilders
{
    public sealed class UserReviewViewModelBuilder : IModelBuilder<UserReviewViewModel, UserReviewDM>
    {
        UserReviewViewModel IModelBuilder<UserReviewViewModel, UserReviewDM>.Build(UserReviewDM p)
        {
            return new UserReviewViewModel
            {
                Comments = p.Comments,
                Id = p.Id,
                RatingsDescription = p.RatingsDescription,
                RatingsLevel = p.RatingsLevel,
                RatingsRef = p.RatingsRef,
                RestaurantIdRef = p.RestaurantIdRef,
                Title = p.Title,
                UserIdRef = p.UserIdRef,
                RatingsRepresentation = TranslateRatingsLevelForRepresentation(p.RatingsLevel)
            };
        }

        private string TranslateRatingsLevelForRepresentation(int ratingsLevel)
        {
            const string STAR = "*";

            string[] ratingsLevelDescriptionBuffer = new string[ratingsLevel];

            for(int i = 0; i < ratingsLevelDescriptionBuffer.Length; i++)
            {
                ratingsLevelDescriptionBuffer[i] = STAR;
            }

            return string.Join(string.Empty, ratingsLevelDescriptionBuffer);
        }
    }
}