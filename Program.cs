using Microsoft.EntityFrameworkCore;
using QSIT.Models;
using QSIT.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QsitDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QSITDB"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Imap,MapRepository>();
builder.Services.AddScoped<ImapType, MapTypeRepository>();
builder.Services.AddScoped<IMapSubType, MapSupTypeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MapConfigration}/{action=Index}/{id?}");

app.Run();
