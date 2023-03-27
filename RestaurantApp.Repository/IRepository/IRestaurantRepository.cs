using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repository.IRepository
{
    public interface IRestaurantRepository:IRepository<Restaurant>
    {
        Task<Restaurant> UpdateAsync(Restaurant entity);

    }
}
