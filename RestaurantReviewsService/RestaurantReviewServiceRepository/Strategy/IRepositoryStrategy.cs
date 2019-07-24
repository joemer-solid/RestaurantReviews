namespace RestaurantReviewServiceRepository.Strategy
{
    public interface IRepositoryStrategy<P,T>
    {
        T Execute(P p);
    }
}
