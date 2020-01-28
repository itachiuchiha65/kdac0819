
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject1.Models;

namespace FinalProject1.Controllers
{
    public class RoleController : ApiController
    {

        finalprojectdbEntities obj = new finalprojectdbEntities();
        // GET: api/Role

         RoleController()
        {
            obj.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<T_Roles> Get()
        {

            return obj.T_Roles.ToList();
        }

        // GET: api/Role/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        public void Post([FromBody]T_Roles role)
        {
            obj.T_Roles.Add(role);
            obj.SaveChanges();
        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody]T_Roles role)
        {
           // obj.proc_ModifyRole(role.RoleName,id);
        }

        // DELETE: api/Role/5
        public void Delete(String RoleName)
        {

            obj.proc_RemoveRole(RoleName);                     
        }
    }
}
