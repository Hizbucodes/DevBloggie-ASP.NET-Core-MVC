using DevBloggie.Web.Models.Domain;

namespace DevBloggie.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Tag> tags { get; set; }
    }
}
