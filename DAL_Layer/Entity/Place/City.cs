using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Layer.Entity.Place
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<District> District { get; set; }
    }
}
