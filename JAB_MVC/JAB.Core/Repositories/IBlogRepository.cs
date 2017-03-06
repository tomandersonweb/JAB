using JAB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAB.Core.Repositories
{
    public interface IBlogRepository
    {
        Blog GetBlog();
    }
}
