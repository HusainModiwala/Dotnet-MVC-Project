using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        [DisplayName("Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [DisplayName("Enter full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter strong password")]
        [DisplayName("Enter Password")]
        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
