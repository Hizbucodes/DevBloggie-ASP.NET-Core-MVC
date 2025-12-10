using DevBloggie.Web.Models.ViewModels;
using DevBloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevBloggie.Web.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository _tagRepository;
        public AdminBlogPostsController(ITagRepository tagRepository)
        {
            this._tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // Get tags from repository
          var tags = await _tagRepository.GetAllAsync();

            var model = new AddBlogPostsRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostsRequest addBlogPostsRequest)
        {

            return RedirectToAction("Add");
        }
    }
}
