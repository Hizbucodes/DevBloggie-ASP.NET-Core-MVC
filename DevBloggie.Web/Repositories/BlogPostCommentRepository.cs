using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly DevBloggieDbContext devBloggieDbContext;

        public BlogPostCommentRepository(DevBloggieDbContext devBloggieDbContext)
        {
            this.devBloggieDbContext = devBloggieDbContext;
        }

        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
           await devBloggieDbContext.BlogPostComment.AddAsync(blogPostComment);
           await devBloggieDbContext.SaveChangesAsync();
           return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
           return await devBloggieDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
