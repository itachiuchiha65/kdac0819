using FinalProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject1.Controllers
{
    public class EmployeeController : ApiController
    {
        Response response = new Response();
        finalprojectdbEntities obj = new finalprojectdbEntities();

        EmployeeController()
        {
            obj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Employee
     
        public IEnumerable<T_EmployeeDetails> Get()
        {
            return (obj.T_EmployeeDetails.ToList());
        }

        // GET: api/Employee/5
        public Response Get(int id)
        {
            IEnumerable<T_EmployeeDetails> employee = obj.T_EmployeeDetails.ToList();
            T_EmployeeDetails employeelist = (from u in employee
                                      where u.UserId == id
                                      select u).SingleOrDefault();

            if (employeelist != null)
            {

                response.Data = employeelist;
                response.Error = null;
                response.Status = "Success";
                return response;
            }
            else
            {

                response.Error = null;
                response.Status = "Fail";
                return response;

            }
        }

        // POST: api/Employee
        public void Post([FromBody]T_EmployeeDetails details)
        {
            obj.T_EmployeeDetails.Add(details);
            obj.SaveChanges();
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]T_EmployeeDetails Newdetails)
        {
            T_EmployeeDetails old = new T_EmployeeDetails();
            T_EmployeeDetails old1 = obj.T_EmployeeDetails.Find(id);
            old1.Name = Newdetails.Name;
            obj.SaveChanges();
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }

        [HttpPut]
        [Route("api/Employee/UpdateEmployeeDetails")]
        public Response updateEmployeeDetails([FromBody]T_EmployeeDetails value)
        {

            var Employeelist = obj.T_EmployeeDetails.ToList();
            var Employee = (from u in Employeelist
                            where u.UserId == value.UserId
                           select u).SingleOrDefault();

            if (Employee != null)
            {
              //  Employee.UserId= value.UserId;
                Employee.Name = value.Name;
                Employee.Pincode = value.Pincode;
                //Employee.ProductPrice = value.ProductPrice;
                //Employee.CategoryId = value.CategoryId;
                
               
                obj.SaveChanges();
                Response rc = new Response();
                response.Status = "Success";
                response.Error = null;
                response.Data = Employee;
                return response;
            }
            else
            {

                response.Status = "Fail";
                response.Error = null;
                response.Data = null;
                return response;
            }
        }




    }
}
