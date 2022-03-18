using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
    }
}