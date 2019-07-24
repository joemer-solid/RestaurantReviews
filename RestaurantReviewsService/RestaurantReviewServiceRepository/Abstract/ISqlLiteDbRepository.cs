using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewServiceRepository.Entities;
using System.Data.SQLite;

namespace RestaurantReviewServiceRepository.Abstract
{
    public interface ISqlLiteDbRepository : IDbRepository<EntityModelBase, object> { }
    
}
