using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewServiceRepository.EntityModelBuilders
{
    public interface IEntityModelBuilder<T, P>
    {
        T Build(P p);
    }
}
