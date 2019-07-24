using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewServiceRepository.Commands.Builder
{
    public interface ISqlLiteCommandBuilder<T>
    {
        T Build();
    }
}
