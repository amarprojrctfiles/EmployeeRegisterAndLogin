using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeRegisterAndLogin.Models;

namespace EmployeeRegisterAndLogin.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]

        public ActionResult AddOrEdit()
        {
            EmployeeTable Employee = new EmployeeTable();
            return View(Employee);
        }
        [HttpPost]

        public ActionResult AddOrEdit(EmployeeTable employee)
        {
            using(DBModels dbmodel1 = new DBModels())
            {

                dbmodel1.EmployeeTables.Add(employee);
                dbmodel1.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMassege = "Registration Successful.";
            return View("AddOrEdit", new EmployeeTable());
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]

    public ActionResult Login(EmployeeTable login)
        {
            using (DBModels dbmodel1 = new DBModels())
            {
                var emp = dbmodel1.EmployeeTables.Single(e => e.Email == login.Email && e.Password == login.Password);
                if(emp != null)
                {
                    Session["EmployeeId"] = emp.EmployeeId.ToString();
                    Session["FirstName"] = emp.FirstName.ToString();
                    return RedirectToAction("Loggedin");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong.");

                }
            }
            return View();
        }
        public ActionResult Loggedin()
        {
            if (Session["EmployeeId"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}