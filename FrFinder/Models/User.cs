using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class User
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        //Package Table Relation
        public Package Package { get; set; }
        public int PackageId { get; set; }
        //Package Table Relation

        public bool Status { get; set; }
        //Table Relations
        public List<UserInformation> UserInformations { get; set; }
        public List<Post> Posts { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Comment> Comments { get; set; }
        //Table Relations
    }
}