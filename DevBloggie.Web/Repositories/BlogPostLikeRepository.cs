
using DevBloggie.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly DevBloggieDbContext _devBloggieDbContext;

        public BlogPostLikeRepository(DevBloggieDbContext devBloggieDbContext)
        {
            this._devBloggieDbContext = devBloggieDbContext;
        }

        public async Task<int> GetTotalLikes(Guid BlogPostId)
        {
           return await _devBloggieDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == BlogPostId);
        }
    }
}
