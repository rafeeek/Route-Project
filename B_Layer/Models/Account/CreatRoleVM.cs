using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models.Account
{
    public class CreatRoleVM
    {
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
    }
}
