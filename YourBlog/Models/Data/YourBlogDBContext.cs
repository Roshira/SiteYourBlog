using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace YourBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

   
    }
}