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
    public class FinderController : Controller
    {
        Ffinder_Database db = new Ffinder_Database();
     
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetID(int ID)
        {
            List<User> users = db.users.ToList();
            User user = users.FirstOrDefault(x => x.Id == ID);

            MatchRequest match = new MatchRequest();
            Match matches = new Match();

            var authuser = db.matchRequests.Where(x => x.SenderId == ID && x.ReceiverId == Convert.ToInt32(Session["UserId"])).FirstOrDefault();
            if (authuser == null)
            {
                match.SenderId = Convert.ToInt32(Session["UserId"]);
                match.ReceiverId = Convert.ToInt32(ID);
                match.Status = false;

                db.matchRequests.Add(match);
                db.SaveChanges();
            }
            else
            {
                matches.SenderId = Convert.ToInt32(Session["UserId"]);
                matches.ReceiverId = Convert.ToInt32(ID);
                matches.Status = false;

                db.matches.Add(matches);
                db.SaveChanges();

            }

            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Finder()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Finder(string receiver)
        {
            MatchRequest match = new MatchRequest();

            match.SenderId = Convert.ToInt32(Session["UserId"]);
            match.ReceiverId = Convert.ToInt32(receiver);
            match.Status = false;

            db.matchRequests.Add(match);
            db.SaveChanges();


            return View();
        }
       

    }
}