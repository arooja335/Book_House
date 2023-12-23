using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookHouse.Data;
using BookHouse.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BookHouseDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BookHouseDbContextConnection' not found.");

builder.Services.AddDbContext<BookHouseDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BookHouseUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BookHouseDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
