using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Ferovi.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Ferovi.Models.Services.Interfaces;
using Ferovi.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

// Configurar el DbContext
builder.Services.AddDbContext<FeroviContext>(options =>
    options.UseLazyLoadingProxies()
           .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar los repositorios
builder.Services.AddScoped<IMenusPrincipalesRepository, MenusPrincipalesRepository>();
builder.Services.AddScoped<IIconosRepository, IconosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IUsuariosRolesRepository, UsuariosRolesRepository>();
builder.Services.AddScoped<IUsuariosHistorialAccesosRepository, UsuariosHistorialAccesosRepository>();

// Registrar los servicios
builder.Services.AddScoped<IPlataformaService, PlataformaService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddRazorPages();

// Configurar el AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
