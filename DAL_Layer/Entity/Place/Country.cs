using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Layer.Entity.Place
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }



        public ICollection<City> City { get; set; }
    }
}
