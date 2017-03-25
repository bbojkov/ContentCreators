using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BulgarianCreators.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Post> postedByUser;
        private ICollection<Post> likedPosts;

        public User()
        {
            this.postedByUser = new HashSet<Post>();
            this.likedPosts = new HashSet<Post>();
        }
        
        public override string Id
        {
            get { return base.Id; }

            set { base.Id = value; }
        }
        
        public virtual Country Country { get; set; }
        
        public virtual ICollection<Post> PostedByUser
        {
            get { return this.postedByUser; }
            set { this.postedByUser = value; }
        }
        
        public virtual ICollection<Post> LikedPosts
        {
            get { return this.likedPosts; }
            set { this.likedPosts = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
