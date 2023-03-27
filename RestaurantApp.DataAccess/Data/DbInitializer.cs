using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DataAccess.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;



        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }


        public void Seed()
        {
            SeedRestaurants();
            SeedCuisines();
        }



        private void SeedCuisines()
        {
            modelBuilder.Entity<Cuisin>().HasData(
            new Cuisin
            {
                Id = 1,
                Name = "Moroccan",
                Description = "Traditional Moroccan dishes",
                Position =1,
                RestaurantId = 1,
            },
            new Cuisin
            {
                Id = 2,
                Name = "French",
                Description = "Traditional French dishes",
                Position = 2,
                RestaurantId = 2,
            }
           
            );
        }

        private void SeedRestaurants()
        {
            modelBuilder.Entity<Restaurant>().HasData(

            new Restaurant
            {
                Id = 1,
                Name = "French Bistro",
                Adress = "456 Second St",
                Description = "A classic French bistro",
                phoneNumber = "1234590",
            },
            new Restaurant
            {
                Id = 2,
                Name = "Sushi Bar",
                Adress = "789 Third St",
                Description = "A trendy Japanese sushi bar",
                phoneNumber = "1234566",
            }
            );
        }




    }
}
