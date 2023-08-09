using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp_Technical_Challenge.Models.ViewModels
{
    public class Employee
    {
        [Display(Name = "Employee Id")]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int Type { get; set; }
        [Required]
        [StringLength(8)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Employment Date")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmploymentDate { get; set; }
    }
}