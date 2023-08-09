using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp_Technical_Challenge.Models;
using CSharp_Technical_Challenge.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeList> lst;
            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                lst = (from d in db.Employee
                       select new EmployeeList
                       {
                           ID = d.ID,
                           Name = d.Name,
                           Telephone = d.Telephone,
                           EmploymentDate = (DateTime)d.EmploymentDate
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(CSharp_Technical_Challenge.Models.ViewModels.Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBShoppingEntities db = new DBShoppingEntities())
                    {

                        var oTabla = new CSharp_Technical_Challenge.Models.Employee();
                        oTabla.Name = model.Name;
                        oTabla.Type = model.Type;
                        oTabla.Telephone = model.Telephone;
                        oTabla.Address = model.Address;
                        oTabla.EmploymentDate = model.EmploymentDate;

                        db.Employee.Add(oTabla);
                        db.SaveChanges();

                    }


                    return Redirect("~/Employee/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            CSharp_Technical_Challenge.Models.ViewModels.Employee model = new CSharp_Technical_Challenge.Models.ViewModels.Employee();

            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                var oTabla = db.Employee.Find(id);
                model.ID = oTabla.ID;
                model.Name = oTabla.Name;
                model.Type = oTabla.Type;
                model.Telephone = oTabla.Telephone;
                model.Address = oTabla.Address;
                model.EmploymentDate = (DateTime)oTabla.EmploymentDate;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CSharp_Technical_Challenge.Models.ViewModels.Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBShoppingEntities db = new DBShoppingEntities())
                    {

                        var oTabla = db.Employee.Find(model.ID);
                        oTabla.Name = model.Name;
                        oTabla.Type = model.Type;
                        oTabla.Telephone = model.Telephone;
                        oTabla.Address = model.Address;
                        oTabla.EmploymentDate = model.EmploymentDate;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }


                    return Redirect("~/Employee/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                var oTabla = db.Employee.Find(Id);

                db.Employee.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Employee/");
        }
    }
}