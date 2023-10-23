using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Vidly.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//try to add authorization
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();
builder.Services.AddDbContext<VidlyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));

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

//todo 1. copy all resources which are required in the app in wwwroot/*,
//todo https://medium.com/executeautomation/repository-pattern-with-entity-framework-in-asp-net-core-6-0-dd35fbc0d934
// https://medium.com/@jaydeepvpatil225/unit-of-work-with-generic-repository-implementation-using-net-core-6-web-api-23d159c63dd4
//todo FluentValidation => 
//todo try to add Identity library for authorization and authentication
//todo remove node modules
//todo 2. ideally use minify in production mode
// to
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = new PathString("/vendor")
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();