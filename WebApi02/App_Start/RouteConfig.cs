using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi02
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "HomeMVC/MainPage",
                defaults: new
                {
                    controller = "HomeMVC",
                    action = "MainPage",
                    
                }
            );
            routes.MapRoute(
               name: "",
               url: "HomeMVC/Employees",
               defaults: new
               {
                   controller = "HomeMVC",
                   action = "Employees",

               }
           );
            routes.MapRoute(
              name: "regist",
              url: "AdminEmployee/employeeRegistr",
              defaults: new
              {
                  controller = "AdminEmployee",
                  action = "employeeRegistr",
              }
          );
            routes.MapRoute(
              name: "",
              url: "AdminEmployee/AddEmployee",
              defaults: new
              {
                  controller = "AdminEmployee",
                  action = "AddEmployee",
              }
          );
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new
                { controller = "HomeMVC",
                    action = "MainPage",
                }
            );
        }
    }
}
