using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class MatchRequest
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool Status { get; set; }

    }
}