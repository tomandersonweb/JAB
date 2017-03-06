using System.Web.Mvc;
using JAB.Core.Services;
using JAB_MVC.ViewModels;
using System.Linq;

namespace JAB_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            var viewModels = _blogService.GetBlogPosts().Select(x => new BlogPostViewModel(x));

            return View(viewModels);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new BlogPostViewModel(_blogService.GetBlogPost(id));

            return View(viewModel);
        }
    }
}