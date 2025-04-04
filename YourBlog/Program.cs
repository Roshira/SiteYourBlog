using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models.Data;
using YourBlog.Models.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// ������ ������������
var configuration = builder.Configuration;

// �������� �������� ����� ����������
var connectionString = configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json");
}

// ������ ����� DbContext � ���������
builder.Services.AddDbContext<YourBlogDBContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});

// ������ Identity
builder.Services.AddIdentity<UserViewModel, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<YourBlogDBContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������������ ������� HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // � ����� �������� ����������� ������� �����������
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<YourBlogDBContext>();
            context.Database.Migrate(); // ����������� ������������ �������
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();