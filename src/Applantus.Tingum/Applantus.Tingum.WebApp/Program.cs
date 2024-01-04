using Applantus.Tingum.Core.Interfaces;
using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers;
using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers.IRoles;
using Applantus.Tingum.Core.Services;
using Applantus.Tingum.Infrastruture.Data;
using Applantus.Tingum.Infrastruture.Data.Repositories;
using Applantus.Tingum.Infrastruture.Data.Repositories.AppUsers;
using Applantus.Tingum.Infrastruture.Data.Repositories.AppUsers.Roles;
using Applantus.Tingum.Infrastruture.Services;
using Applantus.Tingum.Infrastruture.Services.Passwords;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ~ benkimz: add database and custom services
builder.Services.AddDbContext<SystemDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBString"), b => b.MigrationsAssembly("Applantus.Tingum.WebApp"));
});

// ~ users repository
builder.Services.AddTransient<IPasswordHashing, PasswordHashing>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IAppUsersRepository, AppUsersRepository>();
builder.Services.AddTransient<IUserRolesRepository, UserRolesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
