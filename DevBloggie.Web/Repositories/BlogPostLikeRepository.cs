
using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
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

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await _devBloggieDbContext.BlogPostLike.AddAsync(blogPostLike);
            await _devBloggieDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
           return await _devBloggieDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid BlogPostId)
        {
           return await _devBloggieDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == BlogPostId);
        }
    }
}
