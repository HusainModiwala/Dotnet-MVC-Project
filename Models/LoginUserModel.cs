using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Models
{
    public class LoginUserModel
    {
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
