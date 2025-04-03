// Models/Data/YourBlogDBContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models;
using YourBlog.Models.UserModels;

namespace YourBlog.Models.Data
{
    public class YourBlogDBContext : IdentityDbContext<User>
    {
        public YourBlogDBContext(DbContextOptions<YourBlogDBContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Додаткові конфігурації моделі, якщо потрібно
        }
    }
}