using Microsoft.EntityFrameworkCore;
using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;
using PlanificatorProiecte.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adaugare servicii conectare baza de date
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PlanificatorProiecteConnectionString")));
//Adaugare servicii (implementare servicii)
builder.Services.AddScoped<IProiectService,ProiectService>();
builder.Services.AddScoped<IAngajatService, AngajatService>();
builder.Services.AddScoped<IStareAlocareService, StareAlocareService>();
builder.Services.AddScoped<IAlocareService, AlocareService>();

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
    pattern: "{controller=Alocare}/{action=GetAll}/{id?}");

app.Run();
