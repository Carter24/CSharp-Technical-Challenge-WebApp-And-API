using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp_Technical_Challenge.Models;
using CSharp_Technical_Challenge.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            List<ShopList> lst;
            using (DBShoppingEntities db = new DBShoppingEntities())
            {
                lst = (from d in db.Shop
                       select new ShopList
                       {
                           ID = d.ID,
                           Name = d.Name,
                           Telephone = d.Telephone,
                           Addres = d.Address,
                           Id_Employee = (int)d.ID_Employee

                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(CSharp_Technical_Challenge.Models.ViewModels.Shop model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    using (DBShoppingEntities db = new DBShoppingEntities())
                    {
                        var date = new DateTime();
                        date = System.DateTime.Now;
                       

                                var table = new CSharp_Technical_Challenge.Models.Shop();
                                table.Shop_Date = date;
                                table.Name = model.Name;
                                table.Address = model.Address;
                                table.Telephone = model.Telephone;
                                table.ID_Employee = model.ID_Employee;

                                db.Shop.Add(table);
                                db.SaveChanges();
                            
                    }
                    return Redirect("~/Shop/");
                }
                catch (Exception ex)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('" + ex.Message + "');</script>");
                }
            }
            return View(model);
        }          
    }
}
