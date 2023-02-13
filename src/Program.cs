using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using project_foodie.Data;
using project_foodie.Model;

var builder = WebApplication.CreateBuilder(args);

//Load env variables
DotNetEnv.Env.Load();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#region db
//register db context
builder.Services.AddDbContextFactory<DatabaseContext>();

#endregion

var app = builder.Build();

Global.Environment = app.Environment;
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
class Global
{
    public static IHostEnvironment Environment { get; set; }
}
