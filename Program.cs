using Microsoft.EntityFrameworkCore;
using skill_test.DataContext;
using skill_test.Interfaces;
using skill_test.Services.LoginServices;
using skill_test.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    services.AddScoped<IUser, UserServices>();
    services.AddScoped<ILogin, LoginServices>();

    services.AddDbContext<skill_set_dbContext>(options => options.UseMySql("server=localhost;user=root;password=dummy;database=skill_set_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.1.9-mariadb")));
    // Add services to the container.
    services.AddControllersWithViews();
}

var app = builder.Build();
{
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
        pattern: "{controller=Login}/{action=LoginPage}/{id?}");

    app.Run();

}

