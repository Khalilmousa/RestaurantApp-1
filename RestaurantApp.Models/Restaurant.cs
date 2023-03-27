using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string phoneNumber { get; set; }
        public string Adress { get; set; }
        public virtual List<Cuisin> Cuisins { get; set; }
    }
}
