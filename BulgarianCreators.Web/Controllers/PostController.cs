using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Web.Mapping;
using BulgarianCreators.Web.Models;
using Bytes2you.Validation;
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
        private readonly IMapperAdapter mapperAdapter;

        public PostController(IPostService postService, ICategoryService categoryService, IMapperAdapter mapperAdapter)
        {
            Guard.WhenArgument(postService, "postService").IsNull().Throw();
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();
            Guard.WhenArgument(mapperAdapter, "mapperAdapter").IsNull().Throw();

            this.postService = postService;
            this.categoryService = categoryService;
            this.mapperAdapter = mapperAdapter;
        }

        public ActionResult Index()
        {
            var blogPosts = this.postService.GetAllPost().ToList();

            if (blogPosts == null)
            {
                return this.View("Error");
            }

            var postViewModel = this.mapperAdapter.Map<IEnumerable<PostViewModel>>(blogPosts);

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
        public async Task<ActionResult> Create(AddPostViewModel postModel)
        {
            if (ModelState.IsValid)
            {
                Category category = categoryService.GetCategoryByName(postModel.Category);

                var post = new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = postModel.Title,
                    ImageUrl = postModel.ImageUrl,
                    Content = postModel.Content,
                    Category = category
                };

                this.postService.CreateNewPost(post.Title, post.ImageUrl, post.Category.CategoryName, post.Content);
            }

            this.TempData["Notification"] = "You've uploaded successfully a new post";
            return RedirectToAction("Index", "Post");
        }

    }
}