using System.ComponentModel.DataAnnotations;

namespace DevBloggie.Web.Models.ViewModels
{
    public class AddTagRequest
    {
        
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
    }
}
