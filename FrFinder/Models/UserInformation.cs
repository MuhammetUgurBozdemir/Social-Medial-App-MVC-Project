using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        //User table relations
        public User User { get; set; }
        public int UserId { get; set; }
        //User table relations
        public string UserPhoto { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string UserPhone { get; set; }
        public bool Status { get; set; }


    }
}