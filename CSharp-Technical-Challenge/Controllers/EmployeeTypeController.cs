using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp_Technical_Challenge.Models;
using CSharp_Technical_Challenge.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class EmployeeTypeController : Controller
    {
        // GET: EmployeType
        public ActionResult Index()
        {
            List<EmployeeTypeList> lst;
            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                lst = (from d in db.EmployeeType
                       select new EmployeeTypeList
                       {
                           ID = d.ID,
                           Name = d.Name,
                           Salary = (int)d.Salary
                       }).ToList();
            }
            return View(lst);
        }
    }
}
