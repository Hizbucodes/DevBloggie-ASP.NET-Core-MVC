using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;

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
           await devBloggieDbContext.AddAsync(blogPostComment);
           await devBloggieDbContext.SaveChangesAsync();
           return blogPostComment;
        }
    }
}
