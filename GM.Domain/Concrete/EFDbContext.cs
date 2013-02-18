using System.Data.Entity;
using GM.Domain.Entities;

namespace GM.Domain.Concrete {

    class EFDbContext : DbContext {

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
