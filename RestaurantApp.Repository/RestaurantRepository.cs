using RestaurantApp.DataAccess.Data;
using RestaurantApp.Models;
using RestaurantApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repository
{
    public class RestaurantRepository : Repository<Restaurant>,IRestaurantRepository
    {
        private readonly ApplicationDbContext _db;

        public RestaurantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public  async Task<Restaurant> UpdateAsync(Restaurant entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
