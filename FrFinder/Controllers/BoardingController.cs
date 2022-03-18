using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Data.Entity;
using System.Web.Security;//Giriş Kontrolü Kütüphanesi
using FrFinder.Models;

namespace FrFinder.Controllers
{
    public class BoardingController : Controller
    {
        Ffinder_Database db = new Ffinder_Database();
      

        string verifcode = "";
     
      
        

        // GET: Boarding
        public ActionResult Index()
        {
            return View();
        }

        public void getCode()
        {
            User user = new User();
            Authenticator auth = new Authenticator();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            verifcode = finalString;

       
        }

       
        [HttpGet]
        public ActionResult Boarding()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Boarding(string name, string password, string email)
        {
            User user = new User();
            Authenticator auth = new Authenticator();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            var usermail = db.users.Where(x => x.Email == email).FirstOrDefault();
            if(usermail == null)
            {
                user.Name = name;
                user.Email = email;
                user.Password = password;
                user.PackageId = 1;



                db.users.Add(user);
                db.SaveChanges();
                var authuser = db.users.Where(x => x.Email == email && x.Password == password).OrderByDescending(x => x.Id).FirstOrDefault();
                auth.UserId = authuser.Id;
                auth.Token = finalString;
                verifcode = finalString;
                db.authenticators.Add(auth);
                db.SaveChanges();

                Response.Redirect("~/Boarding/Login");
               
            }
            else
            {
                ViewBag.mail = "Mail Adresi Sisteme Kayitli";
            }

            return View(user);




        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string mail , string password)
        {
            
            
            var user = db.users.Where(x => x.Email == mail && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                if (user.Status == true)                   
                {
                    Session["UserId"] = user.Id.ToString();
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Verification", "Boarding");
                }
            }
            else
            {
                ViewBag.message = "Giriş Hatalı";
               
            }
               
            return View(user);
        }
        [HttpGet]
        public ActionResult Verification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verification(string vercode)
        {
            
            var authuser = db.authenticators.Where(x => x.Token == vercode).FirstOrDefault();
            var ID = authuser.UserId;
            var user = db.users.Where(x => x.Id == ID).FirstOrDefault();

            if (vercode == authuser.Token)
            {
                user.Status = true;
                Response.Redirect("~/Home/Index");
                db.SaveChanges();
            }
            

            return View(user);
        }
       
       
        public JsonResult SendMailToUser(string matchvalue)
        {
            getCode();            
            bool result = false;
            result = SendEmail(matchvalue, "Verification Code", verifcode);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SendEmail(string toEmail,string subject, string emailBody)
        {
            try
            {

                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);


                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);



                return true;
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }
    }
}