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

                        var table = new CSharp_Technical_Challenge.Models.Employee();
                        table.Name = model.Name;
                        table.Type = model.Type;
                        table.Telephone = model.Telephone;
                        table.Address = model.Address;
                        table.EmploymentDate = model.EmploymentDate;

                        db.Employee.Add(table);
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
                var table = db.Employee.Find(id);
                model.ID = table.ID;
                model.Name = table.Name;
                model.Type = table.Type;
                model.Telephone = table.Telephone;
                model.Address = table.Address;
                model.EmploymentDate = (DateTime)table.EmploymentDate;
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

                        var table = db.Employee.Find(model.ID);
                        table.Name = model.Name;
                        table.Type = model.Type;
                        table.Telephone = model.Telephone;
                        table.Address = model.Address;
                        table.EmploymentDate = model.EmploymentDate;

                        db.Entry(table).State = System.Data.Entity.EntityState.Modified;
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
                var table = db.Employee.Find(Id);

                db.Employee.Remove(table);
                db.SaveChanges();
            }
            return Redirect("~/Employee/");
        }
    }
}