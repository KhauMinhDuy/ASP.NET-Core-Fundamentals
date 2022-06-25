using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants { get; set; }

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {id  = 1, Name = "Khau Minh Duy", Location ="VietName", CuisineType = CuisineType.Italian },
                new Restaurant {id  = 2, Name = "Huyen Viet Anh Phi", Location ="VietName", CuisineType = CuisineType.Mexican },
                new Restaurant {id  = 3, Name = "Nguyen Ha Anh", Location ="VietName", CuisineType = CuisineType.Italian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants orderby r.Name select r;
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants where string.IsNullOrEmpty(name) || r.Name.StartsWith(name) orderby r.Name select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.id == id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.id == updateRestaurant.id);
            if(restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.CuisineType = updateRestaurant.CuisineType;
                restaurant.Location = updateRestaurant.Location;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.id = restaurants.Max(r => r.id) + 1;
            return newRestaurant;
        }
    }
}
