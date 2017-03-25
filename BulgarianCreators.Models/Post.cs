using BulgarianCreators.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BulgarianCreators.Models
{
    public class Post : IPost
    {
        private ICollection<Comment> comments;
        private ICollection<User> userLikes;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.userLikes = new HashSet<User>();
        }

        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public virtual User PostedBy { get; set; }

        public DateTime PostedOn { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<User> UserLikes
        {
            get { return this.userLikes; }
            set { this.userLikes = value; }
        }
    }
}