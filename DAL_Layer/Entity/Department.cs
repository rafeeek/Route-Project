using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Layer.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
