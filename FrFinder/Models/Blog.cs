using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Blog
    {
        public int Id { get; set; }
        //Admin table relations
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        //Admin table relations
        public string Tittle { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
    }
}