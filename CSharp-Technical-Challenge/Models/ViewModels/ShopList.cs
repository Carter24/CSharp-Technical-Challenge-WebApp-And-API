using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp_Technical_Challenge.Models.ViewModels
{
    public class ShopList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}