using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrFinder.Models;

namespace FrFinder.SiteModels
{
    public class HomeModel
    {
        public List<Match> matchedFriends { get; set; }
        public List<Post> friendsPosts { get; set; }
    }
}