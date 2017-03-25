using BulgarianCreators.Models;
using BulgarianCreators.Web.Mapping;

namespace BulgarianCreators.Web.Models
{
    public class AddPostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
    }
}