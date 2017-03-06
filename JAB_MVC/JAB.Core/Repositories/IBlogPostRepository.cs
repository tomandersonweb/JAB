using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAB.Core.Entities;

namespace JAB.Core.Repositories
{
    public interface IBlogPostRepository
    {
        BlogPost GetById(int postId);
        IList<BlogPost> GetAll(bool onlyPublished = true);

        void Remove(BlogPost blogPost);

        void AddPost(BlogPost blogPost);
    }
}