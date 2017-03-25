using BulgarianCreators.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace BulgarianCreators.Models
{
    public class Comment : IComment
    {
        public Guid Id { get; set; }

        public DateTime PostedOn { get; set; }

        public string commentBody { get; set; }

        public virtual User PostedBy { get; set; }
    }
}