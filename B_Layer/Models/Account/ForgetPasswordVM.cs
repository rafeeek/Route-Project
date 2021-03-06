using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models.Account
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Email Address Required")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
