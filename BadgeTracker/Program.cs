using BadgeTracker.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

string DB_CONNECTION = "BadgeTrackerConnection";

var builder = WebApplication.CreateBuilder(args);

DbContextFactory.SetConnectionString(DB_CONNECTION);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Set connection string.
builder.Services.AddDbContext<TrackerDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString(DB_CONNECTION));
});
builder.Services.AddAntDesign();

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
