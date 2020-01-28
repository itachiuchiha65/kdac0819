using FinalProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject1.Controllers
{
    public class TimelogController : ApiController
    {
        finalprojectdbEntities obj = new finalprojectdbEntities();
        Response response = new Response();
        TimelogController()
        {
            obj.Configuration.ProxyCreationEnabled = false;

        }
        // GET: api/Timelog
        public IEnumerable<T_TimeLog> Get()
        {
            return obj.T_TimeLog.ToList();
        }

        // GET: api/Timelog/5
        public Response Get(int id)
        {
            List<T_TimeLog> employee = obj.T_TimeLog.ToList();
            IEnumerable<T_TimeLog> timeloglist = (from u in employee
                                     where u.UserId == id
                                     select u);

            if (timeloglist != null)
            {

                response.Data = timeloglist;
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

        // POST: api/Timelog
        public Response Post([FromBody]T_TimeLog value)
        {
            
            value.LoggedIn = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime thisday = DateTime.Today;
            value.TodayDate = thisday;
            var res= obj.T_TimeLog.Add(value);
            obj.SaveChanges();
            Response result = new Response();
            result.Data = res;
            result.Status = "success";
            result.Error = null;
            return result;
        }

        [HttpPost]
        [Route("api/Timelog/Loggout")]
        public T_TimeLog Loggout([FromBody]T_TimeLog value)
        {
           value.LoggedOut = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            var emp = obj.T_TimeLog.Find(value.AttendanceId);
            emp.LoggedOut = value.LoggedOut;
           // emp.AttendanceStatus = "Present";
            //emp.WorkingHours = Convert.ToInt32(emp.LoggedOut - emp.LoggedIn);
            obj.SaveChanges();
            return emp;
        }

        // PUT: api/Timelog/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE: api/Timelog/5
        public void Delete(int id)
        {
        }
    }
}
