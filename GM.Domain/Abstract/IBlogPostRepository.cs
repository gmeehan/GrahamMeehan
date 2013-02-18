using System.Linq;
using GM.Domain.Entities;

namespace GM.Domain.Abstract {

    public interface IBlogPostRepository {

        IQueryable<BlogPost> BlogPosts { get; }
    }
}
