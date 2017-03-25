using BulgarianCreators.Models;
using BulgarianCreators.Web.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BulgarianCreators.Web.Models
{
    public class PostViewModel : IMapFrom<Post>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }
        
        public Category Category { get; set; }

        public User PostedBy { get; set; }

        public DateTime PostedOn { get; set; }

        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<User> UserLikes { get; set; }
    }
}