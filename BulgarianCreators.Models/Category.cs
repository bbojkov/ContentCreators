using BulgarianCreators.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulgarianCreators.Models
{
    public class Category : ICategory
    {
        private ICollection<Post> postsByCategory;

        public Category()
        {
            this.postsByCategory = new HashSet<Post>();
        }
        
        public Guid Id { get; set; }

        public string CategoryName { get; set; }
    }
}