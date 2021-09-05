using DAL_Layer.Entity.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<City> City { get; set; }
    }
}
