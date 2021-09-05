using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Models.Account
{
     public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min Length Is 5 Char")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Not Matching")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min Length Is 5 Char")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

    }
}
