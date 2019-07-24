using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewsService.DataAdapters;
using RestaurantReviewsService.DomainModels;

namespace RestaurantReviewUnitTests
{
    [TestClass]
    public class DataAdaptersTests
    {
        private const string _testCategory = "DataAdapterTests";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void CanGetAllRestaurantsDomainModelList()
        {
            try
            {
                IRestaurantsDataAdapter restaurantsDataAdapter = new RestaurantsDataAdapter();

                IList<RestaurantDM> results = restaurantsDataAdapter.GetAllRestaurants();

                Assert.IsTrue(results != null);

                Assert.IsTrue(results.Count > 0);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void CanGetRestaurantDomainModelListByCityName()
        {
            try
            {
                string cityName = "Twin Peaks";

                IRestaurantsDataAdapter restaurantsDataAdapter = new RestaurantsDataAdapter();

                IList<RestaurantDM> results = restaurantsDataAdapter.GetRestaurantsByCity(cityName);

                Assert.IsTrue(results != null);

                Assert.IsTrue(results.Count > 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void WillGenerateExceptionOnDuplicateRestaurantAddAttempt()
        {
          
            RestaurantDM duplicateAddAttempt = new RestaurantDM
            {
                City = "Butler",
                Name = "Mama Rosa",
                Overview = "Italian Cuisine From Old Country Recipes",
                StateId = 1,
                StreetAddress = "123 Old Butler Plank Road"
            };

            int addResult = 0;

            try
            {
                IRestaurantsDataAdapter restaurantsDataAdapter = new RestaurantsDataAdapter();

                addResult = restaurantsDataAdapter.AddNewRestaurant(duplicateAddAttempt);

                Assert.Fail();
            }
            catch(AssertFailedException e)
            {
                Assert.Fail(e.Message);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e is Exception);
            }
        }
    }
}
