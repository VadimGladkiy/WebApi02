using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi02.DAO;

namespace WebApi02.Infrastructure
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (ModelTest _DBEntity = new ModelTest())
            {
                return _DBEntity.Users.Any(x => x.username
                .Equals(username, StringComparison.OrdinalIgnoreCase) 
                && x.password == password);
                
            }
        }
    }
}