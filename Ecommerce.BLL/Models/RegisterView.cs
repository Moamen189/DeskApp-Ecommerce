using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class RegisterView
    {
        [Required (ErrorMessage = "Email is Required") ]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]

        public string Password   { get; set; }
        [Compare("Password", ErrorMessage ="Confirm Password does not match password")]
        public string  ConfirmPassword { get; set; }  
    }
}
