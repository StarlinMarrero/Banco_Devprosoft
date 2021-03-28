using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco_Devprosoft.Models;
using Banco_Devprosoft.Data;
using Microsoft.AspNetCore.Identity;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Authorize]
    [Area("Banking")]
    public class UsuariosController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;
        public UsuariosController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Perfil()
        {
            return View();
        }
        [Authorize(Roles ="Gerente")]
        public IActionResult Creacion_De_Usuarios()
        {
            return View();
        }

        public JsonResult Crear_Usuario(ApplicationUser usuario_Recibido)
        {
            var validation = db.Users.Where(m => m.Cedula == usuario_Recibido.Cedula).FirstOrDefault();

            if(validation != null)
            {

                return Json(new { title = "Creación de Usuarios", text = $"Ya existe un usuario con la cédula {usuario_Recibido.Cedula}.", icon = "info" });

            }

            var Primer_Nombre = usuario_Recibido.Nombres.Split(" ")[0];
            var Primer_Apellido = usuario_Recibido.Apellidos.Split(" ")[0];

            var model = new ApplicationUser
            {
                UserName = $"{Primer_Nombre}_{Primer_Apellido}",
                Nombres = usuario_Recibido.Nombres,
                Apellidos = usuario_Recibido.Apellidos,
                Cedula = usuario_Recibido.Cedula,
                Telefono = usuario_Recibido.Telefono,
                Email = usuario_Recibido.Email,
                Direccion = usuario_Recibido.Direccion,
                Fecha_Creacion = DateTime.Now,
                EmailConfirmed = true
            };

            var crear_User = userManager.CreateAsync(model, "Acceso.123");
            crear_User.Wait();

            var asignar_Rol = userManager.AddToRoleAsync(model, "Representante");
            asignar_Rol.Wait();



            return Json(new { title = "Creación de Usuarios", text = $"Usuario {model.Nombres} {model.Apellidos} creado exitósamente.", icon = "success" });
        }
    }
}
