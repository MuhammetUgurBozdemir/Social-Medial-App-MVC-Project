using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrFinder.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
    }
}