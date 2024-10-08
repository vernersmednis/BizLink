using BizLinkk.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Profiling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register PrakseContext with the DI container
builder.Services.AddDbContext<PrakseContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Configure MiniProfiler
builder.Services.AddMiniProfiler(options =>
{
    // Route to view the profiler results
    options.RouteBasePath = "/profiler";

    // Optional: To profile SQL commands, add EF Core support if you're using Entity Framework
    options.TrackConnectionOpenClose = true;
}).AddEntityFramework();

var app = builder.Build();

// Use MiniProfiler middleware
app.UseMiniProfiler();

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
