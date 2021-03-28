using Banco_Devprosoft.Data;
using Banco_Devprosoft.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Transient);
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
                options.SignIn.RequireConfirmedAccount = true
                ).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();


            services.Configure<IdentityOptions>(options =>
            {

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1440);
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. //Comentario Starlin Marrero
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapRazorPages();


            });




            Create_Users_Roles(serviceProvider);
        }

        public void Create_Users_Roles(IServiceProvider service)
        {

            //Obtener servicios de Usuarios y Roles
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();


            //Verificación de existencia de roles
            var role1 = roleManager.RoleExistsAsync("Cliente");
            role1.Wait();

            var role2 = roleManager.RoleExistsAsync("Gerente");
            role2.Wait();

            var role3 = roleManager.RoleExistsAsync("Representante");
            role3.Wait();

            //Creación de los roles
            if(role1.Result == false)
            {
                var crear_Rol = roleManager.CreateAsync(new IdentityRole("Cliente"));
                crear_Rol.Wait();
            }
            if (role2.Result == false)
            {
                var crear_Rol = roleManager.CreateAsync(new IdentityRole("Gerente"));
                crear_Rol.Wait();
            }
            if (role3.Result == false)
            {
                var crear_Rol = roleManager.CreateAsync(new IdentityRole("Representante"));
                crear_Rol.Wait();
            }

            //Verificación de las cuentas
            var Gerente_User = userManager.FindByEmailAsync("gerente@mail.com");
            Gerente_User.Wait();

            var Representante_User = userManager.FindByEmailAsync("representante@mail.com");
            Representante_User.Wait();

            var Cliente_User = userManager.FindByEmailAsync("cliente@mail.com");
            Cliente_User.Wait();

            //Creación de los usuarios

            if (Gerente_User.Result == null) { 

                var Gerente_Modelo = new ApplicationUser
                {
                    UserName = "Gerente_User",
                    Cedula = "402-4567891-8",
                    Nombres = "Daniela",
                    Apellidos = "Slim",
                    Email = "gerente@mail.com",
                    EmailConfirmed = true,

                };

                userManager.CreateAsync(Gerente_Modelo, "Acceso.123").Wait();
                userManager.AddToRoleAsync(Gerente_Modelo, "Gerente").Wait();

            }

            if (Representante_User.Result == null)
            {

                var Representante_Modelo = new ApplicationUser
                {
                    UserName = "Representante_User",
                    Cedula = "223-4567891-6",
                    Nombres = "Cindy",
                    Apellidos = "Nerodsky",
                    Email = "representante@mail.com",
                    EmailConfirmed = true,

                };
                userManager.CreateAsync(Representante_Modelo, "Acceso.123").Wait();
                userManager.AddToRoleAsync(Representante_Modelo, "Representante").Wait();

            }

            if (Cliente_User.Result == null)
            {

                var Cliente_Modelo = new ApplicationUser
                {
                    UserName = "Cliente_User",
                    Cedula = "123-4567891-0",
                    Nombres = "Marcos",
                    Apellidos = "Polo",
                    Email = "cliente@mail.com",
                    EmailConfirmed = true,

                };
                userManager.CreateAsync(Cliente_Modelo, "Acceso.123").Wait();
                userManager.AddToRoleAsync(Cliente_Modelo, "Cliente").Wait();

            }





        }
    }
}
