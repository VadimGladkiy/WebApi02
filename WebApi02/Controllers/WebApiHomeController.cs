using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi02.Infrastructure;
using WebApi02.DAO;


namespace WebApi02.Controllers
{
    public class WebApiHomeController : ApiController
    {
        private ModelTest _DBContext; 
        public WebApiHomeController()
        {
            _DBContext = new ModelTest();
        }
        [HttpPost]
        public HttpResponseMessage PostEmployee([FromBody]Employee anewEmp)
        {
            _DBContext.Employees.Add(anewEmp);
            _DBContext.SaveChanges();

            var message = Request.CreateResponse(HttpStatusCode.Created, anewEmp);
            message.Headers.Location = 
                new Uri(Request.RequestUri + anewEmp.Emp_Id.ToString());
            return message;
        }
        [HttpGet]
        [EmployeeAuthenteficationAttribute]
        public IHttpActionResult getAllEmployees()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;
            IEnumerable<Employee>CurrentPerson = _DBContext.Employees
                .Where(x => x.first_name+x.last_name == userName).ToList();

            //return Request.CreateResponse(HttpStatusCode.OK, box);
            //return box;
            return Ok(CurrentPerson);
             
        }
        [HttpGet]
        public HttpResponseMessage getEmployeeById(int Id)
        {
            Employee temp;
            temp = _DBContext.Employees.Where(x => (x.Emp_Id == Id)).First();
            if (temp != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Employee with Id= "+Id.ToString() +" does not exist");
            }

        }
        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int emp_id)
        {
            var deleteEmp = _DBContext.Employees.First(x => x.Emp_Id == emp_id);
            if (deleteEmp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Employee with id " + emp_id.ToString() +" not found to delete");
            }
            else
            {
                _DBContext.Employees.Remove(deleteEmp);

                _DBContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            
        }
        [HttpPut]
        public HttpResponseMessage PutEmployee(int input_id, [FromBody] Employee anewEmp)
        {
            var wantedEmp = _DBContext.Employees.First(x => x.Emp_Id == input_id);
            if (wantedEmp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Employee with id " + input_id.ToString() + " not found to update");
            }
            else
            {
                wantedEmp.first_name = anewEmp.first_name;
                wantedEmp.last_name = anewEmp.last_name;
                wantedEmp.gender = anewEmp.gender;
                wantedEmp.salary = anewEmp.salary;

                _DBContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, anewEmp); 
            }
        }
    }
}
