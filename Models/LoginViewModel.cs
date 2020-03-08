using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admission.Models
{
    public class LoginViewModel
    {
        public int L_Id { get; set; }

        [Required(ErrorMessage = "Please enter your E-mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string L_Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string L_Password { get; set; }

        public string L_Designation { get; set; }
    }
}