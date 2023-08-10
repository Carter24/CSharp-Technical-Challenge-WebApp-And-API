using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp_Technical_Cahellenge_WebAPI.Models;

namespace CSharp_Technical_Cahellenge_WebAPI.Controllers
{
    public class APIEmployeeController : Controller
    {
        // GET: Employee
        public dynamic Index()
        {
            List<Employee> lst = new List<Employee>();
             using (DBShoppingEntities db = new DBShoppingEntities())
             {
                 foreach (var table in db.Employee )                        
                 {
                     lst.Add(new Employee() { ID = table.ID, 
                         Name = table.Name, 
                         Type = table.Type, 
                         Telephone = table.Telephone,
                         Address = table.Address,
                         EmploymentDate = table.EmploymentDate
                     });
                 }
             }
             return lst;
        }

        // GET: Employee/Details/5
        public dynamic Details(int id)
        {
            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                Employee lst = new Employee();
                var table = db.Employee.Find(id);
                lst.ID = table.ID;
                lst.Name = table.Name;
                lst.Type = table.Type;
                lst.Telephone = table.Telephone;
                lst.Address = table.Address;
                lst.EmploymentDate = (DateTime)table.EmploymentDate;
                return lst;
            }
        }

        [HttpPost]
        public dynamic Create(Employee model)
        {
            using (DBShoppingEntities db = new DBShoppingEntities())
            {

                try
                {
                    var table = new Employee();
                    table.Name = model.Name;
                    table.Type = model.Type;
                    table.Telephone = model.Telephone;
                    table.Address = model.Address;
                    table.EmploymentDate = model.EmploymentDate;

                    db.Employee.Add(table);
                    db.SaveChanges();

                    return db.Employee.ToList();
                }
                catch
                {
                    return db.Employee.ToList(); ;
                }
            }
        }

        
        // GET: Employee/Edit/5
        public dynamic Edit(int id)
        {
            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                Employee lst = new Employee();
                var table = db.Employee.Find(id);
                lst.Name = table.Name;
                lst.Type = table.Type;
                lst.Telephone = table.Telephone;
                lst.Address = table.Address;
                lst.EmploymentDate = (DateTime)table.EmploymentDate;
                return lst;
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public dynamic Edit(Employee model)
        {
            try
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

                    return db.Employee.ToList();
                }
            }
            catch
            {
                using (DBShoppingEntities db = new DBShoppingEntities())
                {
                    var table = db.Employee.Find(model.ID);
                    return db.Employee.ToList();
                }
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public dynamic Delete(int id)
        {
            try
            {
                using (DBShoppingEntities db = new DBShoppingEntities())
                {
                    var table = db.Employee.Find(id);

                    db.Employee.Remove(table);
                    db.SaveChanges();
                    return db.Employee.ToList();
                }
            }
            catch
            {
                using (DBShoppingEntities db = new DBShoppingEntities())
                {
                    return db.Employee.ToList();
                }
            }
        }
    }
}
