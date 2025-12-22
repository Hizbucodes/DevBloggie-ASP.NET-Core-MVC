using DevBloggie.Web.Models.Domain;

namespace DevBloggie.Web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        public Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        public Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
    }
}
