using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp_Technical_Challenge.Models.ViewModels
{
    public class Shop
    {
        [Display(Name = "Shop Id")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Employee Id")]
        public int ID_Employee { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }
    }
}