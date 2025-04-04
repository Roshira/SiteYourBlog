using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models.Data;
using YourBlog.Models.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Додаємо конфігурацію
var configuration = builder.Configuration;

// Перевірка наявності рядка підключення
var connectionString = configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json");
}

// Додаємо сервіс DbContext з перевіркою
builder.Services.AddDbContext<YourBlogDBContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});

// Додаємо Identity
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

// Налаштування конвеєра HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // У режимі розробки застосовуємо міграції автоматично
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<YourBlogDBContext>();
            context.Database.Migrate(); // Автоматичне застосування міграцій
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