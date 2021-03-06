using PetShop.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Repositories;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;
using PetShop.Service;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlite("Data Source=c:\\temp\\user.db"));
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationContext>();


builder.Services.AddDbContext<PetShopDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PetShopDataConnection")));


builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
