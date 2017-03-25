using BulgarianCreators.Models;
using System.Data.Entity;

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
