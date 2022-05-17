﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{

    public class Restaurant
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType CuisineType { get; set; }

    }
}
