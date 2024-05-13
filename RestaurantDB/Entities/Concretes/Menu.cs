using RestaurantDB.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDB.Entities
{
    public class Menu:Entity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ?ImageUrl { get; set; }
    }
}
