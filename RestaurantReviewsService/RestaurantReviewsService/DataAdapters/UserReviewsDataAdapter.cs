using RestaurantReviewService.Entities;
using RestaurantReviewService.Operations;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ModelBuilders;
using RestaurantReviewsService.ModelBuilders.DataEntityModelBuilders;
using RestaurantReviewsService.ModelBuilders.DomainModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReviewsService.DataAdapters
{
    public sealed class UserReviewsDataAdapter : IUserReviewsDataAdapter
    {
        int IUserReviewsDataAdapter.AddNewUserReview(UserReviewDM userReviewDM)
        {
            throw new NotImplementedException();
        }

        int IUserReviewsDataAdapter.DeleteExistingUserReview(UserReviewDM userReviewDM)
        {
            throw new NotImplementedException();
        }

        IList<UserReviewDM> IUserReviewsDataAdapter.GetUserReviewsForRestaurant(RestaurantDM restaurantDm)
        {
            throw new NotImplementedException();
        }

        IList<UserReviewDM> IUserReviewsDataAdapter.GetUserReviewsForUser(UserDM userDm)
        {
            IModelBuilder<UserReviewDM, UserReview> modelBuilder = new UserReviewDomainModelBuilder();
            ISelectUserReviewsOperation selectUserReviewsOperation = new SelectUserReviewsOperation();
            IList<UserReviewDM> results = new List<UserReviewDM>();

            IList<UserReview> operationResults = selectUserReviewsOperation.SelectByUser(
                new User() { Id = userDm.Id });

            if (operationResults != null && operationResults.Count > 0)
            {
                foreach (UserReview userReview in operationResults)
                {
                    results.Add(modelBuilder.Build(userReview));
                }
            }

            return results;
        }
    }
}