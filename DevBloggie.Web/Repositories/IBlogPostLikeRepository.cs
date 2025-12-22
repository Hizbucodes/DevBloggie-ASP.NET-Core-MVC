namespace DevBloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        public Task<int> GetTotalLikes(Guid BlogPostId);
    }
}
