using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Authenticator
    {
        public int Id { get; set; }
        //User Table Relation
        public User User { get; set; }
        public int UserId { get; set; }
        //User Table Relation
        public string Token { get; set; }
        public bool Status { get; set; }
    }
}