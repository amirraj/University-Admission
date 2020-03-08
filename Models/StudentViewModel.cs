using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admission.Models
{
    public class StudentViewModel
    {
        public int S_Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string S_Name { get; set; }

        [Required(ErrorMessage = "Please enter your E-mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string S_Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Please enter numbers only")]
        public int S_Phone { get; set; }

        public Nullable<double> S_Marks { get; set; }
        public Nullable<int> S_Attendence { get; set; }
        public Nullable<int> E_Year { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string L_Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        [Compare("L_Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}