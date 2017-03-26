using BulgarianCreators.Models;
using BulgarianCreators.Web.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulgarianCreators.Web.Models
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public string commentBody { get; set; }
    }
}