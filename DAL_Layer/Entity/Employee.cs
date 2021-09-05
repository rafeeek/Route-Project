using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using DAL_Layer.Entity.Place;

namespace DAL_Layer.Entity
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        [StringLength(50)]
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string PhotoPath { get; set; }

        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }



        public District District { get; set; }
        public Department Department { get; set; }
    }
}
