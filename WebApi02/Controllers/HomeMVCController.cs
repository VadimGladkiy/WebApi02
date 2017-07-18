using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi02.DataModel;

namespace WebApi02.Controllers
{
    public class HomeMVCController : Controller
    {
        // GET: MainPage
        public ActionResult MainPage()
        { 
            return View();
        }
        [HttpGet]
        [ActionName("Employees")]
        public ActionResult Employees_Get()
        {
            ModFromCode _DataContext = new ModFromCode();
            List<Employee> all = new List<Employee>();
            if (_DataContext.Employees.Count() > 0)
            {
                all = _DataContext.Employees.ToList();
                return PartialView("_AllEmployees", all);
            }
            else
            {
                return new EmptyResult();
            }
        }
        [HttpPost]
        [ActionName("Employees")]
        public ActionResult Employees_Post()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_AllEmployees");
            }
            else
            {
                return new EmptyResult();
            }

        }

    }
}