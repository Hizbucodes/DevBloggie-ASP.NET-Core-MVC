using DevBloggie.Web.Models.Domain;

namespace DevBloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        public Task<int> GetTotalLikes(Guid BlogPostId);

        public Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
        public Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
