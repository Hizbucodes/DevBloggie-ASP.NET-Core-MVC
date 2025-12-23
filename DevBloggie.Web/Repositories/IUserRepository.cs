using Microsoft.AspNetCore.Identity;

namespace DevBloggie.Web.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<IdentityUser>> GetAllAsync();
    }
}
