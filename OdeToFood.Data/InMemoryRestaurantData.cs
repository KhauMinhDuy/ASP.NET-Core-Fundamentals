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
                new Restaurant {Id  = 1, Name = "Khau Minh Duy", Location ="VietName", CuisineType = CuisineType.Italian },
                new Restaurant {Id  = 2, Name = "Nguyen Thanh Long", Location ="VietName", CuisineType = CuisineType.Mexican },
                new Restaurant {Id  = 3, Name = "Nguyen Duc Thanh", Location ="VietName", CuisineType = CuisineType.Italian }
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
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if (restaurant != null)
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
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurant()
        {
            return restaurants.Count;
        }
    }
}
