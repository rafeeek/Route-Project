using DAL_Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [MaxLength(20 , ErrorMessage = "max Length 20")]
        [MinLength(3, ErrorMessage = "max Length 3")]
        [Required(ErrorMessage = "Required")]
        public string DepartmentName { get; set; }
        [MaxLength(15, ErrorMessage = "max Length 20")]
        [MinLength(3, ErrorMessage = "max Length 3")]
        public string DepartmentCode { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
