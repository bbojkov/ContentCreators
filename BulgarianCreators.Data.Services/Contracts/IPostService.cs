using BulgarianCreators.Models;
using System;
using System.Linq;

namespace BulgarianCreators.Data.Services.Contracts
{
    public interface IPostService
    {
        Post GetById(Guid postId);

        IQueryable<Post> GetAllPost();

        //IQueryable<Post> GetAllPostsByUser(User user);

        void CreateNewPost(string title, string imageUrl, string category, string content, User postedBy);
    }
}
