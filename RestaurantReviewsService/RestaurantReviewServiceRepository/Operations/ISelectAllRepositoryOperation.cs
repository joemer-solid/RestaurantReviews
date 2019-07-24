using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewServiceRepository.Operations
{
    public interface ISelectAllRepositoryOperation<T>
    {
        T SelectAll();
    }
}
