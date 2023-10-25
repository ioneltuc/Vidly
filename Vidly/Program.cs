using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Vidly.Infrastructure;
using Vidly.Services;
using Vidly.Services.Interfaces;
using Vidly.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MovieProfile), typeof(CustomerProfile), typeof(MembershipTypeProfile));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
//todo ASYNC/AWAIT

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();