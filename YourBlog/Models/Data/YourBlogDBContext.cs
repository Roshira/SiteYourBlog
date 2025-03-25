using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models.UserModels;

namespace YourBlog.Models.Data
{
    public class YourBlogDBContext : IdentityDbContext<User>
    {
        public YourBlogDBContext(DbContextOptions<YourBlogDBContext> options)
            : base(options)
        {
        }

 
    }
}