using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
using DevBloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> SubmitTag(AddTagRequest addTagRequest)
        {
            var tag = new Tag
{
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,

            };

           await devBloggieDbContext.Tags.AddAsync(tag);
           await devBloggieDbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var results = await devBloggieDbContext.Tags.ToListAsync();

            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await devBloggieDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if(tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };

                return View(editTagRequest);

            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };

           var existingTag = await devBloggieDbContext.Tags.FindAsync(tag.Id);

            if(existingTag == null)
            {
                return RedirectToAction("Edit", new {id=editTagRequest.Id});
            }

            existingTag.Name = tag.Name;
            existingTag.DisplayName = tag.DisplayName;

           await devBloggieDbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var tag = await devBloggieDbContext.Tags.FindAsync(editTagRequest.Id);

            if(tag == null)
            {
                return RedirectToAction("Edit", new { id = editTagRequest.Id});
            }

            devBloggieDbContext.Remove(tag);
           await devBloggieDbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

    }
}
