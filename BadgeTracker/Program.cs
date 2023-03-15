using BadgeTracker.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

string DB_CONNECTION = "BadgeTrackerConnection";

var builder = WebApplication.CreateBuilder(args);

DbContextFactory.SetConnectionString(DB_CONNECTION);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<TrackerDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString(DB_CONNECTION));
});
builder.Services.AddTransient<IEarnablesService, EarnablesService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddAntDesign();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
