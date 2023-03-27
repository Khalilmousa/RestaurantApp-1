using AutoMapper;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            //Restaurant
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
            CreateMap<Restaurant, RestaurantCreateDTO>().ReverseMap();
            CreateMap<Restaurant, RestaurantUpdateDTO>().ReverseMap();

        }
    }
}
