using System;
using FrFinder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FrFinder.SiteModels;
using System.IO;

namespace FrFinder.Controllers
{
    public class HomeController : Controller
    {
        Ffinder_Database db = new Ffinder_Database();
        

        // GET: Home
        public ActionResult Index()
        {
            Session["UserId"] = 2.ToString();
            HomeModel homeModel = new HomeModel();

            var matchFriends = (IEnumerable<Match>)(from f in db.matches where f.SenderId == 2 select f);
            homeModel.matchedFriends = matchFriends.ToList();

            List<Post> postList =new List<Post>();
            
            foreach (var friend in homeModel.matchedFriends)
            {
                
                var post = (IEnumerable<Post>)(from p in db.posts where p.UserId == friend.ReceiverId select p);
                foreach(var p in post)
                {
                    postList.Add(p);
                }

                homeModel.friendsPosts = postList;            
            }
           



            return View(homeModel);
        }

        [HttpPost]
        public ActionResult CreatePost(HttpPostedFileBase postImg, string postTxt)
        {
            int usId = Convert.ToInt32(Session["UserId"]);
            Post post = new Post();
            string imgpath = "";
            string imgname = "";
            try
            {
                if (postImg != null && postImg.ContentLength > 0)
                {
                    imgname = Guid.NewGuid().ToString() + "-" + Path.GetFileName(postImg.FileName);
                    imgpath = Path.Combine(Server.MapPath("~/Content/images/postpics"), imgname);
                    postImg.SaveAs(imgpath);
                    post.Photo = imgname;
                }
            }
            catch
            { }
            int ıd = Convert.ToInt32(Session["userId"]);
            post.UserId = usId;
            post.Description = postTxt;
            post.date = DateTime.Now;
            post.Status = true;
            db.posts.Add(post);
            db.SaveChanges();
            Response.Redirect("~/Home/Index");
            return View();
        }

        public ActionResult Friends()
        {
            var matchFriends = (IEnumerable<Match>)(from t in db.matches where t.SenderId == 2 select t);
            List<User> friendLists = new List<User>();
            int count = matchFriends.Count();
            foreach(var y in matchFriends)
            {
                var friend = (IEnumerable<User>)(from x in db.users where x.Id == y.ReceiverId  select x);
                foreach(var f in friend)
                {
                    friendLists.Add(f);
                }
                int count2 = friend.Count();
            }

            return View(friendLists);
        }

        public ActionResult Usertimeline()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var posts = (IEnumerable<Post>)(from p in db.posts where p.UserId == userId select p);
            List<Post> postList = new List<Post>();
            foreach (var p in posts)
            {
                postList.Add(p);
            }

            return View(postList);
        }

        public ActionResult Userabout()
        {

            return View();
        }
        [HttpPost] 
        public ActionResult Userabout(HttpPostedFileBase userimg,string username,string usersurname,string userphone,
            string useremail,string usercountry,string userstate,string usercity,string userprovince)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var user = db.users.Find(userId);
            var userInf = db.userInformations.Where(x=>x.UserId==userId).FirstOrDefault();

            string imgpath = "";
            string imgname = "";
            try
            {
                if (userimg != null && userimg.ContentLength > 0)
                {
                    imgname = Guid.NewGuid().ToString() + "-" + Path.GetFileName(userimg.FileName);
                    imgpath = Path.Combine(Server.MapPath("~/Content/images/profilepics"), imgname);
                    userimg.SaveAs(imgpath);
                    userInf.UserPhoto = imgname;
                }
            }
            catch
            { }
            user.Name = username;
            user.Surname = usersurname;
            userInf.UserPhone = userphone;
            user.Email = useremail;
            userInf.Country = usercountry;
            userInf.State = userstate;
            userInf.City = usercity;
            userInf.Province = userprovince;
            db.SaveChanges();
            Response.Redirect("~/Home/Userabout");
            return View();
        }
    }
}