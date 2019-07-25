using RestaurantReviewService.Abstract;
using RestaurantReviewService.Concrete;
using RestaurantReviewService.Entities;
using System.Collections.Generic;

namespace RestaurantReviewService.Operations
{
    public interface ISelectUserReviewsOperation
    {
        IList<UserReview> SelectByUser(User user);

        IList<UserReview> SelectByRestaurant(Restaurant restuarant);
    }

    public sealed class SelectUserReviewsOperation : ISelectUserReviewsOperation
    {
        public IList<UserReview> SelectByRestaurant(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }

        public IList<UserReview> SelectByUser(User user)
        {
            ISqlLiteDbRepository usersReviewRepository = new UserReviewsRepository<User>(
                new UserReviewsFilterParams<User>
                {
                     Criteria = user,
                     FilterType = UserReviewsRepository<User>.SelectAllFilterType.ByUserId
                });


            return (IList<UserReview>)usersReviewRepository.SelectAll();
   
        }
      
    }
}
