namespace JAB.Persistence.EF.Migrations
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JAB.Persistence.EF.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JAB.Persistence.EF.BlogContext context)
        {
            context.BlogPosts.AddOrUpdate(
            b => b.Id,  new BlogPost() { Id = 1, PostTitle = "Default Blog Post Title", PostBody = "Default Blog Post Body", Date = DateTime.Now, Publish = true}
            );

            context.SaveChanges();

            context.Blogs.AddOrUpdate(
              p => p.Id, new Blog() { Id = 1, BlogTitle = "Simple Blog", BlogDescription = "Welcome to my blog"}
            );

            context.SaveChanges();
        }
    }
}
