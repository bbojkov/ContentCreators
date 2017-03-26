using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Web.Mapping;
using BulgarianCreators.Web.Models;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BulgarianCreators.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly IMapperAdapter mapperAdapter;

        public PostController(
            IPostService postService,
            ICategoryService categoryService,
            IMapperAdapter mapperAdapter,
            IUserService userService)
        {
            Guard.WhenArgument(postService, "postService").IsNull().Throw();
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();
            Guard.WhenArgument(mapperAdapter, "mapperAdapter").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.postService = postService;
            this.categoryService = categoryService;
            this.mapperAdapter = mapperAdapter;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var blogPosts = this.postService.GetAllPost();

            if (blogPosts == null)
            {
                return this.View("Error");
            }

            var postViewModel = this.mapperAdapter.Map<IEnumerable<PostViewModel>>(blogPosts.ToList());

            return this.View(postViewModel);
        }

        public ActionResult SingleBlogPost(Guid id)
        {
            var blogPost = this.postService.GetById(id);

            if (blogPost == null)
            {
                return this.View("Error");
            }

            var postViewModel = this.mapperAdapter.Map<PostViewModel>(blogPost);

            return this.View(postViewModel);
        }


        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddPostViewModel postModel)
        {
            if (ModelState.IsValid)
            {
                Category category = categoryService.GetCategoryByName(postModel.Category);

                var userId = User.Identity.GetUserId();
                var user = this.userService.GetUserById(userId);


                var post = new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = postModel.Title,
                    ImageUrl = postModel.ImageUrl,
                    Content = postModel.Content,
                    Category = category,
                    PostedBy = user
                };

                this.postService.CreateNewPost(post.Title, post.ImageUrl, post.Category.CategoryName, post.Content, post.PostedBy);
                this.TempData["Notification"] = "You've uploaded successfully a new post";
            }

            return RedirectToAction("Index", "Post");
        }
    }
}