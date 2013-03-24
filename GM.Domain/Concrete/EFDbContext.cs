using System.Data.Entity;
using GM.Domain.Entities;
using System;

namespace GM.Domain.Concrete {

    public class EFDbContext : DbContext {
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
