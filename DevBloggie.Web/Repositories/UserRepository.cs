using DevBloggie.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevBloggie.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            var users = await authDbContext.Users.ToListAsync();

            var superAdminUser = await authDbContext
                .Users
                .FirstOrDefaultAsync(x => x.Email == "superAdmin@bloggie.com");

            if(superAdminUser is not null)
            {
                users.Remove(superAdminUser);
            }

            return users;
        }
    }
}
