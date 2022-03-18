using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //User table relations
        public User User { get; set; }
        public int UserId { get; set; }
        //User table relations

        //Post table relations
        public Post Post { get; set; }
        public int PostId { get; set; }
        //Post table relations
        public string Text { get; set; }
        public bool Status { get; set; }

    }
}