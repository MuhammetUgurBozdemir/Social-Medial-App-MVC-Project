using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class AdminPermission
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public bool Status { get; set; }

        //Table Relations
        public List<Admin> Admins { get; set; }
        //Table Relations
    }
}