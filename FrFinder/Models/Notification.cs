using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
    }
}