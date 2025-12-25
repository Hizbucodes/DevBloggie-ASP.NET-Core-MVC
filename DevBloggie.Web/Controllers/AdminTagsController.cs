using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
using DevBloggie.Web.Models.ViewModels;
using DevBloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {

        private readonly ITagRepository _tagRepository;
        public AdminTagsController(ITagRepository tagRepository)
        {

            this._tagRepository = tagRepository;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            ValidateAddTagRequest(addTagRequest);

            if (!ModelState.IsValid)
            {
                return View();
            }

            var tagDomainModel = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,

            };

            await _tagRepository.AddAsync(tagDomainModel);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List(
            string? searchQuery,
            string? sortBy,
            string? sortDirection,
            int pageSize = 3,
            int pageNumber = 1
            )
        {

            var totalRecords = await _tagRepository.CountAync();
            var totalPages = Math.Ceiling((decimal)totalRecords / pageSize);

            if (pageNumber > totalPages)
            {
                pageNumber--;
            }

            if (pageNumber < 1)
            {
                pageNumber++;
            }

            ViewBag.TotalPages = totalPages;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SortBy = sortBy;
            ViewBag.SortDirection = sortDirection;
            ViewBag.PageSize = pageSize;
            ViewBag.PageNumber = pageNumber;

            var results = await _tagRepository.GetAllAsync(searchQuery, sortBy, sortDirection, pageNumber, pageSize);

            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await _tagRepository.GetAsync(id);

            if (tag is not null)
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

            var updatedTag = await _tagRepository.UpdateAsync(tag);

            if (updatedTag is not null)
            {
                // Show successfull message
            }
            else
            {
                // Show error message
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await _tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag is not null)
            {
                return RedirectToAction("List");

            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });



        }

        private void ValidateAddTagRequest(AddTagRequest addTagRequest)
        {
            if (addTagRequest.Name is not null && addTagRequest.DisplayName is not null)
            {
                if (addTagRequest.Name == addTagRequest.DisplayName)
                {
                    ModelState.AddModelError("DisplayName", "The Name cannot be same as DisplayName");
                }
            }
        }

    }
}
