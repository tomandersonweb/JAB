using JAB.Core.Entities;
using JAB.Core.Services;
using JAB.Persistence.EF;
using JAB_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JAB_MVC.Controllers
{
    public class BlogAdminController : Controller
    {
        private IBlogService _blogService;

        public BlogAdminController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            var viewModels = _blogService.GetAllBlogPosts().Select(x => new BlogPostViewModel(x));
            return View(viewModels);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogPostViewModel viewModel)
        {
            try
            {
                var blogPost = new BlogPost();

                TryUpdateModel(blogPost);

                _blogService.AddBlogPost(blogPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new BlogPostViewModel(_blogService.GetBlogPost(id));
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, BlogPostViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var model = _blogService.GetBlogPost(vm.Id);

            try
            {
                TryUpdateModel(model);
                _blogService.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _blogService.DeletePost(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
