using RestaurantReviewServiceRepository.Abstract;
using RestaurantReviewServiceRepository.Commands.Builder;
using RestaurantReviewServiceRepository.Entities;
using RestaurantReviewServiceRepository.EntityModelBuilders;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace RestaurantReviewServiceRepository.Concrete
{
    public sealed class RestaurantsRepository : ISqlLiteDbRepository
    {
        void IDbRepository<EntityModelBase, object>.Delete(EntityModelBase entity)
        {
            throw new NotImplementedException();
        }

        object IDbRepository<EntityModelBase, object>.Insert(EntityModelBase entity)
        {
            ISqlLiteCommandBuilder<SQLiteCommand> restaurantAddCommandBuilder = null;
            SQLiteCommand command = null;
            int commandResult = 0;

            try
            {
                using (SqlLiteDbConnection connection = new SqlLiteDbConnection())
                {
                    restaurantAddCommandBuilder = new Restaurant_AddCommand(connection, entity as Restaurant);

                    command = restaurantAddCommandBuilder.Build();

                    commandResult = command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException e)
            {
                throw new Exception(string.Format("SQLite Exception {0} {1}", e.ErrorCode, e.Message));
            }
            catch (Exception e)
            {
                throw e;
            }

            return (object)commandResult;
        }

        void IDbRepository<EntityModelBase, object>.Save(EntityModelBase entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EntityModelBase> IDbRepository<EntityModelBase, object>.SelectAll()
        {
            ISqlLiteCommandBuilder<SQLiteCommand> selectAllRestaurantsCommandBuilder = null;
            SQLiteCommand command = null;
            SQLiteDataReader reader = null;          
            IEntityModelBuilder<IList<Restaurant>, SQLiteDataReader> restaurantsDataEntitiesBuilder = null;
            IList<Restaurant> results = null;

            using (SqlLiteDbConnection connection = new SqlLiteDbConnection())
            {
                selectAllRestaurantsCommandBuilder = new Restaurants_SelectAllCommand(connection);

                command = selectAllRestaurantsCommandBuilder.Build();

                reader = command.ExecuteReader();

                restaurantsDataEntitiesBuilder = new RestaurantsDataEntitiesBuilder();

                results = restaurantsDataEntitiesBuilder.Build(reader);

            }

            return results;
          
        }

        EntityModelBase IDbRepository<EntityModelBase, object>.SelectById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
