using GM.Domain.Entities;
using GM.Domain.Abstract;
using System.Linq;
using System;

namespace GM.Domain.Concrete {

    public class EFBlogPostRepository : IBlogPostRepository {

        private EFDbContext context = new EFDbContext();

        public IQueryable<BlogPost> BlogPosts {
            get { return context.BlogPosts; }
        }

        public void SaveBlogPost(BlogPost blogPost) {

            if (blogPost.Id == 0) {
                context.BlogPosts.Add(blogPost);
            } else {
                BlogPost dbEntry = context.BlogPosts.Find(blogPost.Id);
                if (dbEntry != null) {
                    dbEntry.Title = blogPost.Title;
                    dbEntry.Body = blogPost.Body;
                    dbEntry.Modified = DateTime.Now;
                }
            }
            context.SaveChanges();
        }
    }
}
