using JAB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAB.Core.Services
{
    public interface IBlogService
    {
        Blog GetBlog();

        BlogPost GetBlogPost(int blogId);

        IList<BlogPost> GetBlogPosts();

        IList<BlogPost> GetAllBlogPosts();

        void AddBlogPost(BlogPost blogPost);

        void DeletePost(int blogPostId);

        void Save();
    }
}
