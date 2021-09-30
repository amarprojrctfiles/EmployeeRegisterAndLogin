using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegisterAndLogin.Models
{
    public class EmployeeLogin
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]

        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}