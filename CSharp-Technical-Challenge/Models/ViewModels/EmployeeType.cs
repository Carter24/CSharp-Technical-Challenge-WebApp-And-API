using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp_Technical_Challenge.Models.ViewModels
{
    public class EmployeeType
    {
        [Display(Name = "Id")]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public int Salary { get; set; }
    }
}