using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPagesGeneral.Core;
using RazorPagesGeneral.Data;
using RazorPagesGeneral.Model;
using RazorPagesGeneral.Pages.Services;
using RazorPagesGeneral.Pages.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigurationServices(builder.Services);

var app = builder.Build();

await Seed.SeedUserAndRolesAsync(app);
Configure(app, app.Environment);

app.Run();

void ConfigurationServices(IServiceCollection services)
{
    services.AddSingleton<Order>();
    services.AddSingleton<Ticket>();
    services.AddSingleton<FormattedShedule>();
    services.AddSingleton<IPhotoService,PhotoService>();
    services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

    services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<MovieContext>();

    services.AddMemoryCache();
    services.AddSession();
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

    services.AddDbContext<MovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext") ??
        throw new InvalidOperationException("Connection string 'MovieContext' not found.")));

    services.AddRazorPages();
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (!env.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();
    app.UseEndpoints(x =>
    {
        x.MapRazorPages();
    });
}
