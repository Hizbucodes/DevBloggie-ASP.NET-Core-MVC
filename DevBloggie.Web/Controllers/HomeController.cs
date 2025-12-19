using System.Diagnostics;
using System.Threading.Tasks;
using DevBloggie.Web.Models;
using DevBloggie.Web.Models.ViewModels;
using DevBloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevBloggie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository _blogPostRepository;

        private readonly ITagRepository _tagRepository;

        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blogPostRepository, ITagRepository tagRepository)
        {
            _logger = logger;
            this._blogPostRepository = blogPostRepository;
            this._tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index()
        {
            // getting all blogs
            var blogPosts = await _blogPostRepository.GetAllAsync();
            // get all tags
           var tags = await _tagRepository.GetAllAsync();

            var model = new HomeViewModel
            {
                BlogPosts = blogPosts,
                tags = tags
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
