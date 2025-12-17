using DevBloggie.Web.Models.Domain;
using DevBloggie.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevBloggie.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this._imageRepository = imageRepository;
      
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] IFormFile file)
        {
            Console.WriteLine($"File Name: {file?.FileName}");
            Console.WriteLine($"File Name: {file?.Length}");


            // call a repository
            var imageUrl = await _imageRepository.UploadAsync(file);

            if(imageUrl is null)
            {
                return Problem("Something went wrong", null, (int) HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageUrl });
        }

    }
}
