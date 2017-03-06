using System;
using System.Collections.Generic;
using JAB.Core.Entities;
using JAB.Core.Repositories;
using System.Runtime.Caching;
using JAB.Core.Services;

namespace JAB.Persistence.EF.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly BlogContext _blogContext;

        public BlogService(IBlogRepository blogRepository, IBlogPostRepository blogPostRepository, BlogContext blogContext)
        {
            _blogRepository = blogRepository;
            _blogPostRepository = blogPostRepository;
            _blogContext = blogContext;
        }

        public Blog GetBlog()
        {
            var key = "Blog";
            ObjectCache cache = MemoryCache.Default;

            var cacheItem = cache.GetCacheItem(key);

            if (cacheItem == null)
            {
                var blog = _blogRepository.GetBlog();

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1);
                cache.Set(key, blog, policy);

                return blog;
            }

            return (Blog)cacheItem.Value;

        }

        public BlogPost GetBlogPost(int postId)
        {
            return _blogPostRepository.GetById(postId);
        }

        public IList<BlogPost> GetBlogPosts()
        {
            return _blogPostRepository.GetAll();
        }

        public IList<BlogPost> GetAllBlogPosts()
        {
            return _blogPostRepository.GetAll(true);
        }

        public void AddBlogPost(BlogPost blogPost)
        {
            blogPost.Date = DateTime.Now;
            _blogPostRepository.AddPost(blogPost);
            _blogContext.SaveChanges();
        }

        public void DeletePost(int blogPostId)
        {
            _blogPostRepository.Remove(_blogPostRepository.GetById(blogPostId));
        }

        public void Save()
        {
            _blogContext.SaveChanges();
        }

    }
}
