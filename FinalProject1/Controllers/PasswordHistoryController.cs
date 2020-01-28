using FinalProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject1.Controllers
{
    public class PasswordHistoryController : ApiController
    {
        finalprojectdbEntities obj = new finalprojectdbEntities();

        PasswordHistoryController()
        {
            obj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/PasswordHistory
        public IEnumerable<T_PasswordHistoryLog> Get()
        {
            return obj.T_PasswordHistoryLog.ToList();
        }

        // GET: api/PasswordHistory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PasswordHistory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PasswordHistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PasswordHistory/5
        public void Delete(int id)
        {
        }
    }
}
