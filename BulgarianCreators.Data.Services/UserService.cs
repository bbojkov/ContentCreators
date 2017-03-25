using BulgarianCreators.Data.Services.Contracts;
using System.Linq;
using BulgarianCreators.Models;
using Bytes2you.Validation;

namespace BulgarianCreators.Data.Services
{
    public class UserService : IUserService
    {
        private readonly ICreatorsDbContext dbContext;

        public UserService(ICreatorsDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public User GetUserById(string userId)
        {
            return this.dbContext.Users.Find(userId);
        }

        //public IQueryable<Post> GetUserLikes()
        //{
        //    return this.dbContext.Users.SelectMany(x => x.LikedPosts);
        //}

        public IQueryable<Post> GetUserUploads()
        {
            return this.dbContext.Users.SelectMany(x => x.PostedByUser);
        }
    }
}
