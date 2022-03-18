using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Admin
    {
        public int Id { get; set; }
        //Admin Permission table relations
        public AdminPermission AdminPermission { get; set; }
        public int AdminPermissionId { get; set; }
        //Admin Permission table relations

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }

        //Table relations
        public List<Blog> Blogs { get; set; }
    }
}