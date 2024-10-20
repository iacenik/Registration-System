using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PersonelKayıtSistemi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabanı için DbContext ekliyoruz
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("database");
    options.UseSqlite(connectionString);
});

// Kimlik doğrulama hizmetlerini ekliyoruz
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Login sayfası yönlendirmesi
        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz giriş denemesi yönlendirmesi
    });

var app = builder.Build();

// Uygulama içinde kimlik doğrulama ve yetkilendirme middleware'lerini ekliyoruz
app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization();  // Yetkilendirme

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Kimlik doğrulama middleware'i
app.UseAuthorization();  // Yetkilendirme middleware'i

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
