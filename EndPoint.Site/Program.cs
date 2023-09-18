using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexts;
using Store.Application.Services.Users.Queryes;
using Store.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGetUserSevice, GetUserService>();
builder.Services.AddScoped<IDataBaseContext,DataBaseContext>();
builder.Services.AddScoped<IGetRolesService,GetRolesService>();
string connectionString =
    @"Data Source=DESKTOP-6P4U7CC; Initial Catalog=StoreDb; Integrated Security=True;TrustServerCertificate=true";
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
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
app.MapControllerRoute(
    name : "areas",
    pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();

