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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Додаткові конфігурації моделі, якщо потрібно
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsSubscribed)
                    .HasDefaultValue(false);
            });
        }
    }
}