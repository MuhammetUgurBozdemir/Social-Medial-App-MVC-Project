using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FrFinder.Models
{
    public class DataContext:DbContext
    {
       
       
        public DbSet<User> user { get; set; }

    }
}