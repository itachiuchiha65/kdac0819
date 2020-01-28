using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject1.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace FinalProject1.Controllers
{
    public class UserController : ApiController
    {
        finalprojectdbEntities obj = new finalprojectdbEntities();
       
        Response res = new Response();
        
        UserController()
        {
            obj.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/User
        public Response Get()
        {
            var listuser = obj.T_Users.ToList();
            if(listuser !=null)
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

        [HttpPost]
        [Route("api/User/Register")]
        public void register(T_Users user)
        {
            user.RoleId = 1005;
            obj.T_Users.Add(user);
            obj.SaveChanges();
        }


        [HttpPost]
        [Route("api/User/OTP")]
        public Response OTP([FromBody]dynamic otpDetails)
        {
            string email = otpDetails.EmailId.ToString();


            var userlist = obj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == email
                        select u).SingleOrDefault();
            string o = otpDetails.OTP.ToString();

            var otpd = obj.T_OTP_Details.ToList();
            var vOTP = (from v in otpd
                        where v.UserId == User.UserId && v.OTP == o
                        select v).SingleOrDefault();

            if (vOTP != null)
            {
                Response RC = new Response();
                RC.Status = "success";
                RC.Error = null;
                RC.Data = vOTP;
                return RC;
            }
            else
            {
                Response RC = new Response();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }
        }

        [HttpPost]
        [Route("api/User/IsExist")]
        public Response IsExist([FromBody]T_Users value)
        {

            Email e = new Email();
            var userlist = obj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();
            if (User != null)
            {
                Response RC = new Response();
                string mails = GetOTP();

                T_OTP_Details otp = new T_OTP_Details();
                otp.UserId = User.UserId;
                otp.ValidTill = DateTime.Now;
                otp.GeneratedOn = DateTime.Now;
                otp.OTP = mails;
                obj.T_OTP_Details.Add(otp);
                obj.SaveChanges();
                e.body = "OTP is" + mails;
                e.to = User.EmailId;
                e.subject = "OTP :";
                SendMail(e);

                RC.Status = "success";
                RC.Error = null;
                RC.Data = mails;
                return RC;
            }
            else
            {
                Response RC = new Response();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }

        }

        [HttpPut]
        [Route("api/User/UpdatePassword")]
        public Response updatepassword([FromBody]T_Users value)
        {

            var userlist = obj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();

            if (User != null)
            {
                User.Password = value.Password;
                obj.SaveChanges();
                Response rc = new Response();
                rc.Status = "success";
                rc.Error = null;
                rc.Data = User;
                return rc;
            }
            else
            {
                Response rc = new Response();
                rc.Status = "fail";
                rc.Error = null;
                rc.Data = null;
                return rc;
            }
        }

        private string GetOTP(string otpType = "1", int len = 5)
        {
            //otptype 1 = alpha numeric
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            if (otpType == "1")
            {
                characters += alphabets + small_alphabets + numbers;
            }
            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

        [HttpPost]
        [Route("api/User/SendMail")]
        public String SendMail(Email e)
        {
            string to = e.to;
            string subject = e.subject;
            string body = e.body;

            string result = "Message Sent Successfully..!!";
            string senderID = "sagar.b6565@gmail.com";// use sender’s email id here..
            const string senderPassword = "9552569250"; // sender password here…
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, to, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
                res.Error = ex;
            }
            return result;
        }

    }

    [Route("api/User/upload")]
    public class UploadApiController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> PostFormData()
        {

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/photos");
            var provider = new CustomMultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                Response responseStatus = new Response() { Status = "Success", Error = null };
                return Request.CreateResponse(HttpStatusCode.OK, responseStatus);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }

   
}
