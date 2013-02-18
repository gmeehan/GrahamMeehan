using GM.Domain.Entities;
using GM.Domain.Abstract;
using System.Linq;

namespace GM.Domain.Concrete {

    public class EFBlogPostRepository : IBlogPostRepository {

        private EFDbContext context = new EFDbContext();

        public IQueryable<BlogPost> BlogPosts {
            get { return context.BlogPosts; }
        }
    }
}
