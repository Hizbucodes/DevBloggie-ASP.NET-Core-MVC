using DevBloggie.Web.Data;
using DevBloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DevBloggieDbContext _devBloggieDbContext;

        public BlogPostRepository(DevBloggieDbContext devBloggieDbContext)
        {
            this._devBloggieDbContext = devBloggieDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
          await _devBloggieDbContext.AddAsync(blogPost);
          await _devBloggieDbContext.SaveChangesAsync();

            return blogPost;
        }

        public Task<BlogPost?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _devBloggieDbContext.BlogPosts.Include(x=>x.Tags).ToListAsync();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
