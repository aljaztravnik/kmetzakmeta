using web.Data;
using Microsoft.EntityFrameworkCore;
//using web.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KmetContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("KmetContext")));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<KmetContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128).AddEntityFrameworkStores<KmetContext>().AddDefaultUI().AddDefaultTokenProviders();
            
var app = builder.Build();

// Seed database using DbInitializer 
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<KmetContext>();
    DbInitializer.Initialize(context);
}

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
