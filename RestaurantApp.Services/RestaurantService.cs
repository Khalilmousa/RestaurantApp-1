using AutoMapper;
using RestaurantApp.Models;
using RestaurantApp.Repository.IRepository;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }



        public async Task<RestaurantDTO> GetAsync(int? id, bool tracked= true)
        {
            var restaurant = await _restaurantRepository.GetAsync(u => u.Id == id, tracked);
            return _mapper.Map<RestaurantDTO>(restaurant);
        }

        public async Task<List<RestaurantDTO>> GetAllAsync()
        {
            List<Restaurant> RestaurantList = await _restaurantRepository.GetAllAsync();
            return _mapper.Map<List<RestaurantDTO>>(RestaurantList);
        }

        public async Task DeleteAsync(int? id)
        {

            var restaurant=await GetAsync(id,false);
            await _restaurantRepository.RemoveAsync(_mapper.Map<Restaurant>(restaurant));
        }

        public async Task<RestaurantDTO> CreateAsync(RestaurantCreateDTO createDTO)
        {
            var restaurant = _mapper.Map<Restaurant>(createDTO);
            await _restaurantRepository.CreateAsync(restaurant);
            var resault= _mapper.Map<RestaurantDTO>(restaurant);
            return resault;

        }

        public async Task<RestaurantDTO> UpdateAsync(RestaurantUpdateDTO updateDTO)
        {

            var updatedRestaurant = _mapper.Map<Restaurant>(updateDTO);
            await _restaurantRepository.UpdateAsync(updatedRestaurant);
            return _mapper.Map<RestaurantDTO>(updatedRestaurant);
        }
    }
}
