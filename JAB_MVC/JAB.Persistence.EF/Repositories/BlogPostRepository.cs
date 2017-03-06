using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAB.Core.Entities;
using JAB.Core.Repositories;

namespace JAB.Persistence.EF.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogContext _context;

        protected BlogPostRepository() { }

        public BlogPostRepository(BlogContext context)
        {
            _context = context;
        }
        public BlogPost GetById(int postId)
        {
            return _context.BlogPosts.Where(x => x.Id == postId).FirstOrDefault();
        }

        public IList<BlogPost> GetAll(bool onlyPublished = true)
        {
            var query = _context.BlogPosts;

            if (onlyPublished)
                query.Where(x => x.Publish == onlyPublished);
            
            return query.OrderByDescending(x => x.Date).ToList();
        }

        public void Remove(BlogPost blogPost)
        {
            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
        }

        public void AddPost(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }
    }
}
