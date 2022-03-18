using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FrFinder.Models
{
    public class Ffinder_Database:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public Ffinder_Database() : base("dbConnect")
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<UserInformation> userInformations { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Match> matches { get; set; }
        public DbSet<MatchRequest> matchRequests { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<AdminPermission> adminPermissions { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<Authenticator> authenticators { get; set; }
        public DbSet<Security> securities { get; set; }
        public DbSet<About> abouts { get; set; }    
    }
}