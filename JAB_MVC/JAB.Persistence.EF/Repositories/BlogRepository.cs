using JAB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAB.Core.Entities;

namespace JAB.Persistence.EF.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        protected BlogRepository() { }

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public Blog GetBlog()
        {
            return _context.Blogs.FirstOrDefault();
        }
    }
}
