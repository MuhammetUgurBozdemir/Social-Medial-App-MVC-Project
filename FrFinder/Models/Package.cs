using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public double PackagePrice { get; set; }
        public bool Status { get; set; }

        //Table Relations
        public List<User> Users { get; set; }
    }
}