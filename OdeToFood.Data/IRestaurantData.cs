﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantByName(string name);

        Restaurant GetById(int id);

        Restaurant Update(Restaurant updateRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int GetCountOfRestaurant();

        int Commit();
    }
}
