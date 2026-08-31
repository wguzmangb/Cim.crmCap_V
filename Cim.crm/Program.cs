using Cim.crm.Data;
  using Cim.crm.Models;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.EntityFrameworkCore;

  var builder = WebApplication.CreateBuilder(args);


  var connectionString = builder.Configuration.GetConnectionString("CimCrmConnection")
      ?? throw new InvalidOperationException("Falta la cadena de conexion 'CimCrmConnection'.");

  builder.Services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(connectionString));

  builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
          options.SignIn.RequireConfirmedAccount = false)
      .AddRoles<IdentityRole<int>>()
      .AddEntityFrameworkStores<ApplicationDbContext>();


  // Add services to the container.
  builder.Services.AddControllersWithViews();

  builder.Services.AddRazorPages();


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
  app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    await SembrarDatos.EjecutarAsync(scope.ServiceProvider);
}



  app.Run();