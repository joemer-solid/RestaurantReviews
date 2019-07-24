using RestaurantReviewServiceRepository.Abstract;
using RestaurantReviewServiceRepository.Concrete;
using RestaurantReviewServiceRepository.Entities;
using System.Collections.Generic;

namespace RestaurantReviewServiceRepository.Operations
{
    public interface ISelectAllUsersOperation : IRepositoryOperation<IList<User>, UsersRepository> { }

    public class SelectAllUsersOperation : ISelectAllUsersOperation, ISelectAllRepositoryOperation<IList<User>>
    {
        public IList<User> SelectAll()
        {
            return ((IRepositoryOperation<IList<User>, UsersRepository>)this).Execute(new UsersRepository());
        }

        IList<User> IRepositoryOperation<IList<User>, UsersRepository>.Execute(UsersRepository p)
        {
            return (IList<User>)((ISqlLiteDbRepository)p).SelectAll();
        }
    }
}
