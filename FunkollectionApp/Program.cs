using FunkollectionApp.Data;
using FunkollectionApp.Data.Repositories;
using FunkollectionApp.Services;
using FunkollectionApp.Components;
using FunkollectionApp.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System;
using FunkollectionApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped<IRepository<Pop>, PopRepository>();
builder.Services.AddScoped<IPopService, PopService>();
builder.Services.AddScoped<IPopRepository, PopRepository>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();

builder.Services.AddMudServices();

builder.Services.AddMudServices(options => { options.PopoverOptions.CheckForPopoverProvider = false; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();

}

builder.Services.AddLogging(options =>
{

    options.AddConsole();
    options.AddDebug();

});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{

    try
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        if (app.Environment.IsDevelopment())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            DataSeeder.SeedDevelopment(context);
            logger.LogInformation("Development data seeded");

        }

        if (app.Environment.IsProduction())
        {
            //DataSeeder.SeedProduction(context);
            context.Database.Migrate();
            logger.LogInformation("Production data seeded");
        }


    }
    catch (Exception ex)
    {

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error executing database migration");
    }
}

app.Run();
