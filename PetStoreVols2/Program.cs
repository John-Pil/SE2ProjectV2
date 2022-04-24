using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;
using PetStoreRestAPI3.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AnimalDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
}); builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAnimalRepository, DbAnimalRepository>();
builder.Services.AddScoped<IMerchandiseRepository, DbMerchandiseRepository>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
