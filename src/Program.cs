using Blazored.LocalStorage;
using DotNetEnv;
using project_foodie.Model;
using project_foodie.Repository;
using project_foodie.Service;

var builder = WebApplication.CreateBuilder(args);

//Load env variables
Env.Load();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#region db

//register db context
builder.Services.AddDbContextFactory<DatabaseContext>();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

#endregion

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<BrowserService>();
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error");

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

internal class Global
{
    public static IHostEnvironment Environment { get; set; }
}