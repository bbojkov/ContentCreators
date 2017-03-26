using BulgarianCreators.Data.Services.Contracts;
using System;
using System.Linq;
using BulgarianCreators.Models;
using BulgarianCreators.Models.Factories;
using Bytes2you.Validation;

namespace BulgarianCreators.Data.Services
{
    public class PostService : IPostService
    {
        private readonly ICreatorsDbContext dbContext;
        private readonly ICreatorsDbSaveChangesContext dbSaveChangesContext;

        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        private readonly IPostFactory postFactory;

        public PostService(
            ICreatorsDbContext dbContext,
            ICreatorsDbSaveChangesContext dbSaveChangesContext,
            IPostFactory postFactory,
            ICategoryService categoryService,
            IUserService userService)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(dbSaveChangesContext, "dbSaveChangesContext").IsNull().Throw();
            Guard.WhenArgument(postFactory, "postFactory").IsNull().Throw();
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.dbContext = dbContext;
            this.dbSaveChangesContext = dbSaveChangesContext;

            this.categoryService = categoryService;
            this.userService = userService;

            this.postFactory = postFactory;
        }

        public Post GetById(Guid postId)
        {
            return this.dbContext.Posts.Find(postId);
        }

        public IQueryable<Post> GetAllPost()
        {
            return this.dbContext.Posts.OrderByDescending(p => p.PostedOn);
        }

        //public IQueryable<Post> GetAllPostsByUser(User user)
        //{
        //    return this.dbContext.Posts.Where(x => x.PostedBy == user);
        //}

        public void CreateNewPost(string title, string imageUrl, string category, string content, User postedBy)
        {
            try
            {
                var newPost = this.postFactory.CreatePostInstance();

                newPost.Id = Guid.NewGuid();
                newPost.Title = title;

                newPost.ImageUrl = imageUrl;

                var postCategory = this.categoryService.GetCategoryByName(category);
                newPost.Category = postCategory;

                newPost.PostedOn = DateTime.Now;

                newPost.Content = content;

                newPost.PostedBy = postedBy;

                this.dbContext.Posts.Add(newPost);
                this.dbSaveChangesContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddToFavorites(string userId, Guid postId)
        {
            var user = this.userService.GetUserById(userId);
            var post = this.GetById(postId);

            user.LikedPosts.Add(post);
            post.UserLikes.Add(user);

            this.dbSaveChangesContext.SaveChanges();
        }
    }
}
