using FinalProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject1.Controllers
{
    public class LoginController : ApiController
    {
        finalprojectdbEntities obj = new finalprojectdbEntities();
        // GET: api/Login
        public LoginController()
        {
            obj.Configuration.ProxyCreationEnabled = false;
        }
        Response res = new Response();

        // GET: api/User/Employee
        public Response Get()
        {
            var listuser = obj.T_EmployeeDetails.ToList();
            if (listuser != null)
            {
                res.Data = listuser;
                res.Error = null;
                res.Status = "sucess";
                return res;
            }
            else
            {
                res.Data = listuser;
                res.Error = null;
                res.Status = "sucess";
                return res;
            }

        }

        // POST: api/Login
        public Response Post([FromBody]T_Users login)
        {
            Response response = new Response();
            if(login.EmailId!=null && login.Password!=null)
            {
                var userdtl = obj.T_Users.ToList();
                T_Users userlist = (from User in userdtl
                                    where User.EmailId == login.EmailId &&
                                    User.Password == login.Password
                                    select User).SingleOrDefault();
                if (userlist !=null)
                {
                    response.Data = userlist;
                    response.Error = null;
                    response.Status = "Sucess";
                    return response;
                }
                else
                {
                    response.Error = null;
                    response.Status = "Incorrect Credential";
                    return response;
                }
            }
            else
            {
                response.Error = null;
                response.Status = "Field Are Empty!";
                return response;
            }
            
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
