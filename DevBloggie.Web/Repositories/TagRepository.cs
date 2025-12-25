using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DevBloggieDbContext _dbContext;
        public TagRepository(DevBloggieDbContext devBloggieDbContext)
        {
            this._dbContext = devBloggieDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await _dbContext.AddAsync(tag);
            await _dbContext.SaveChangesAsync();

            return tag;
        }

        public async Task<int> CountAync()
        {
            return await _dbContext.Tags.CountAsync();
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await _dbContext.Tags.FindAsync(id);

            if (existingTag is not null)
            {
                _dbContext.Tags.Remove(existingTag);
                await _dbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync(string? searchQuery, string? sortBy, string? sortDirection, int pageNumber = 1,
            int pageSize = 100)
        {
            var query = _dbContext.Tags.AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(x => x.Name.Contains(searchQuery) || x.DisplayName.Contains(searchQuery));
            }

            // Sorting
            if(!string.IsNullOrWhiteSpace(sortBy))
            {
                var isDesc = string.Equals(sortDirection, "Desc", StringComparison.OrdinalIgnoreCase);

                if(string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                }

                if (string.Equals(sortBy, "DisplayName", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.DisplayName) : query.OrderBy(x => x.DisplayName);
                }

            }

            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;
            query = query.Skip(skipResults).Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await _dbContext.Tags.FindAsync(id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);

            if (existingTag is not null)
            {
                existingTag.Id = tag.Id;
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await _dbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
