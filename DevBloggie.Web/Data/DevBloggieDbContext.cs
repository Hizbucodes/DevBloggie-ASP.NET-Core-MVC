using DevBloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Data
{
    public class DevBloggieDbContext : DbContext
    {
        public DevBloggieDbContext(DbContextOptions<DevBloggieDbContext> options) : base(options)
        {

        }

       public DbSet<BlogPost> BlogPosts { get; set; }
       public DbSet<Tag> Tags { get; set; }
    
    }
}
