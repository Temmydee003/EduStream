using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CRUDApplication.Data;
using CRUDApplication.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CRUDDBContextConnection") ?? throw new InvalidOperationException("Connection string 'CRUDDBContextConnection' not found.");

builder.Services.AddDbContext<CRUDDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CRUDApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) // set to false to prevent user verification
    .AddEntityFrameworkStores<CRUDDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// adding support for razor pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// adding route to support razor pages
app.MapRazorPages();

app.Run();
