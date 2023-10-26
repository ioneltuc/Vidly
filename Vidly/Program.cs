using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Identity.Web.UI;
using Vidly.Infrastructure;
using Vidly.Services;
using Vidly.Services.Interfaces;
using Vidly.Services.Mapper;
using Vidly.Services.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VidlyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<VidlyContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
builder.Services.AddAutoMapper(
    typeof(MovieProfile),
    typeof(CustomerProfile),
    typeof(MembershipTypeProfile),
    typeof(RentalProfile));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();
builder.Services.AddScoped<IRentalService, RentalService>();

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