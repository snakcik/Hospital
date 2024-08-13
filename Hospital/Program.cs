using Hospital.Data.Context;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//dependency injection icin burada tanimlama yapmaya calistim
builder.Services.AddScoped<IDepartman,DepartmanService>();
builder.Services.AddScoped<IInventory, InventoryService>();
builder.Services.AddScoped<IPatient, PatientService>();
builder.Services.AddScoped<IPersonell, PersonellService>();
builder.Services.AddScoped<IPoliclinic, PoliclinicService>();
builder.Services.AddScoped<ITitle, TitleService>();
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

app.Run();
