using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Post
    {
        public int Id { get; set; }
        //User table relations
        public User User { get; set; }
        public int UserId { get; set; }
        //User table relations
        public string Description { get; set; }
        public string Photo { get; set; }
        public DateTime date { get; set; }
        public bool Status { get; set; }


        //Table Relations
        public List<Comment> Comments { get; set; }
        //Table Relations
    }
}