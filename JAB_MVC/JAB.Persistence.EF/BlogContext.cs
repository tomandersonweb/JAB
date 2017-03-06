using System.Data.Entity;
using JAB.Core.Entities;

namespace JAB.Persistence.EF
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext") { }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
