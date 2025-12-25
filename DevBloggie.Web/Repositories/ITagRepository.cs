using DevBloggie.Web.Models.Domain;

namespace DevBloggie.Web.Repositories
{
    public interface ITagRepository
    {
        public Task<IEnumerable<Tag>> GetAllAsync(
            string? searchQuery = null,
            string? sortBy = null,
            string? sortDirection = null,
            int pageNumber = 1,
            int pageSize = 100
            );
        public Task<Tag?> GetAsync(Guid id);
        public Task<Tag> AddAsync(Tag tag);
        public Task<Tag?> UpdateAsync(Tag tag);
        public Task<Tag?> DeleteAsync(Guid id);

        public Task<int> CountAync();

    }
}
