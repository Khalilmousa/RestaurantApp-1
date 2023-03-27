using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IRestaurantService
    {
        //Task<RestaurantDTO> Get(int? id);
        //Task<List<RestaurantDTO>> GetAll();
       // Task<IEnumerable<Restaurant>> GetAll();
        Task<List<RestaurantDTO>> GetAllAsync();
        //RestaurantDTO GetAsync(int? id);
        Task<RestaurantDTO> GetAsync(int? id,bool tracked= true);
        Task DeleteAsync(int? id);
        Task<RestaurantDTO> CreateAsync(RestaurantCreateDTO createDTO);//TODO
        Task<RestaurantDTO> UpdateAsync(RestaurantUpdateDTO updateDTO);

    }
}
