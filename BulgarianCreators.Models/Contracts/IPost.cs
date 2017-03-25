using System;
using System.Collections.Generic;

namespace BulgarianCreators.Models.Contracts
{
    public interface IPost
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string ImageUrl { get; set; }

        Category Category { get; set; }

        User PostedBy { get; set; }

        DateTime PostedOn { get; set; }

        string Content { get; set; }

        ICollection<Comment> Comments { get; set; }

        ICollection<User> UserLikes { get; set; }
    }
}
