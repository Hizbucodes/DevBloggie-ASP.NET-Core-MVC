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

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlogPost = await _devBloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);

            if(existingBlogPost is not null)
            {
                _devBloggieDbContext.BlogPosts.Remove(existingBlogPost);
                await _devBloggieDbContext.SaveChangesAsync();

                return existingBlogPost;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _devBloggieDbContext.BlogPosts.Include(x=>x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            var existingBlogPost = await _devBloggieDbContext.BlogPosts.Include(x=> x.Tags).FirstOrDefaultAsync(x => x.Id == id);

            if(existingBlogPost is not null)
            {
                return existingBlogPost;
            }

            return null;
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            var blogPostUrlHandle = await _devBloggieDbContext.BlogPosts.Include(t => t.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);

            return blogPostUrlHandle;
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await _devBloggieDbContext.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if(existingBlogPost is not null)
            {
                existingBlogPost.Id = blogPost.Id;
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.Visible = blogPost.Visible;
                existingBlogPost.Tags = blogPost.Tags;

                await _devBloggieDbContext.SaveChangesAsync();

                return existingBlogPost;
            }

            return null;
           
        }
    }
}
