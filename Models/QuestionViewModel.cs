using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admission.Models
{
    public class QuestionViewModel
    {
        public int Q_Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int E_Year { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Q_Body { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Op_1 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Op_2 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Op_3 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Op_4 { get; set; }

        public string Op_5 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Q_Answer { get; set; }
    }
}