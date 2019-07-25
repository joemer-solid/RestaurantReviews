using RestaurantReviewsService.PortServices;
using RestaurantReviewsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace RestaurantReviewsService.Controllers
{
    public class RestaurantReviewController : ApiController
    {
        private IRestaurantPortService _restaurantPortService;

        public RestaurantReviewController()
        {
            _restaurantPortService = new RestaurantPortService();
        }



        // GET api/<controller>/5
        [System.Web.Http.HttpGet()]
        public IList<RestaurantViewModel> GetAllRestaurants()
        {
            return _restaurantPortService.GetAllRestaurants();
        }

        [HttpPost()]
        public IList<RestaurantViewModel> ReviewsForCity(string cityName)
        {
            return _restaurantPortService.GetRestaurantReviewsByCity(cityName);
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}