using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi02.DataModel;

namespace WebApi02.Controllers
{
    public class AdminEmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult employeeRegistr()
        {
            return View("Registration");
        }
        [HttpPost]
        public ActionResult AddEmployee(  Employee fresh)
        {
            ModFromCode _dataContext;
            /*
            fresh.Users = new Users()
            {
                username = fresh.first_name + fresh.last_name,
                password = fresh.last_name,
                
            };
            */
            bool r = TryUpdateModel(fresh);
            if (ModelState.IsValid)
                try
                {
                    _dataContext = new ModFromCode();
                    _dataContext.Employees.Add(fresh);
                   // _dataContext.Users.Add(fresh.Users);
                    _dataContext.SaveChanges();
                }
                catch(Exception ex) 
                {
                    ViewData["ExceptMessage"] = ex.Message.ToString();
                    return View("Registration");
                }
            return Redirect("HomeMVC/MainPage");
        }
    }
}