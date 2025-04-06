using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models.ViewModel;
using YourBlog.Models.ViewModels;

namespace YourBlog.Models.Data
{
    public class YourBlogDBContext : IdentityDbContext<UserViewModel>
    {
        public YourBlogDBContext(DbContextOptions<YourBlogDBContext> options)
            : base(options)
        {
        }

        public DbSet<NewsViewModel> News { get; set; }

      
    }
}