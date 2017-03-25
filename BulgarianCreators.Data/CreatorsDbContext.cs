using BulgarianCreators.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BulgarianCreators.Data
{
    public class CreatorsDbContext : IdentityDbContext<User>, ICreatorsDbContext
    {
        public CreatorsDbContext()
            : base("BulgarianCreators")
        {
        }

        public override IDbSet<User> Users
        {
            get { return base.Users; }
            set { base.Users = value; }
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public static CreatorsDbContext Create()
        {
            return new CreatorsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
