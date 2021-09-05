using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Layer.Entity.Place
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
