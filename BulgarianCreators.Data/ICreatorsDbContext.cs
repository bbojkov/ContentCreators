using BulgarianCreators.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Data
{
    public interface ICreatorsDbContext : ICreatorsDbSaveChangesContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Post> Posts { get; }

        IDbSet<Country> Countries { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Category> Categories { get; }
    }
}
