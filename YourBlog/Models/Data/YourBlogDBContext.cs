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

        public DbSet<UserFavoriteNewsViewModel> UserFavoriteNews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Налаштування складеного первинного ключа
            modelBuilder.Entity<UserFavoriteNewsViewModel>()
                .HasKey(ufn => new { ufn.UserName, ufn.NewsId });

            // Налаштування зв'язку з користувачем
            modelBuilder.Entity<UserFavoriteNewsViewModel>()
                .HasOne(ufn => ufn.User)
                .WithMany(u => u.UserFavoriteNews)
                .HasForeignKey(ufn => ufn.UserName);

            // Налаштування зв'язку з новиною
            modelBuilder.Entity<UserFavoriteNewsViewModel>()
                .HasOne(ufn => ufn.News)
                .WithMany(n => n.UserFavoriteNews)
                .HasForeignKey(ufn => ufn.NewsId);
        }
    }
}