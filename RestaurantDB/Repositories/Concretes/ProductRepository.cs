using RestaurantDB.Contexts;
using RestaurantDB.Entities;
using RestaurantDB.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDB.Repositories.Concretes
{
    public class ProductRepository : GenericRepository<Menu>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
