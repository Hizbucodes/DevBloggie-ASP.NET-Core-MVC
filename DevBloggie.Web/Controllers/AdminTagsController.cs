using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
using DevBloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevBloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly DevBloggieDbContext devBloggieDbContext;

        public AdminTagsController(DevBloggieDbContext devBloggieDbContext)
        {
            this.devBloggieDbContext = devBloggieDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag(AddTagRequest addTagRequest)
        {
            var tag = new Tag
{
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,

            };

            devBloggieDbContext.Tags.Add(tag);
            devBloggieDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            var results = devBloggieDbContext.Tags.ToList();

            return View(results);
        }
    }
}
