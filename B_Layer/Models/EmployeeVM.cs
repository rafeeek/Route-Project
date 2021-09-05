using DAL_Layer.Entity;
using DAL_Layer.Entity.Place;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage = "MinLength = 3")]
        public string EmployeeName { get; set; }
        [Required]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        [StringLength(50)]
        public string Notes { get; set; }
        public bool IsActive { get; set; }

        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }

        public int DistrictId { get; set; }
        public int DepartmentId { get; set; }

        public District District { get; set; }
        public Department Department { get; set; }
    }
}
