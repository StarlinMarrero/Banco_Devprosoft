using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco_Devprosoft.Data;
using Microsoft.AspNetCore.Identity;
using Banco_Devprosoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Authorize(Roles = "Representante")]
    [Area("Banking")]


    public class SolicitudesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public SolicitudesController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Solicitudes_Pendientes()
        {
            return View();
        }

        public IActionResult Solicitudes_Cuentas()
        {
            return View();
        }

        public IActionResult Solicitudes_Prestamos()
        {
            return View();
        }

        public JsonResult Get_Solicitudes_Cuentas()
        {
            var Solicitudes_Cuentas = db.Solicitudes_Cuentas.Where(x => x.Cerrada == false).ToList();

            return Json(Solicitudes_Cuentas);
        }

        public JsonResult Get_Solicitudes_Prestamos()
        {
            var Solicitudes_Prestamos = db.Solicitudes_Prestamos.Where(x => x.Cerrada == false).ToList();

            return Json(Solicitudes_Prestamos);
        } 
        
     
        
        public JsonResult Aprobar_Solicitud_Cuenta(int Solicitud_ID)
        {

            var solicitud = db.Solicitudes_Cuentas.Find(Solicitud_ID);

            var valid_User = db.Users.Where(x => x.Cedula == solicitud.Cedula).FirstOrDefault();


            if (valid_User != null)
            {
                var Cuenta = new Cuenta_Bancaria
                {
                    Fecha_Creacion = DateTime.Now,
                    Tipo_Cuenta = "Debito",
                    Propietario_ID = valid_User.Id,
                    Balance = 2000,
                    Monto_Maximo = 0,
                    Fecha_De_Corte = DateTime.Now,
                    Fecha_Limite = DateTime.Now
                    

                };

                db.Cuentas_Bancarias.Add(Cuenta);
                db.SaveChanges();
            }
            else
            {
                var Primer_Nombre = solicitud.Nombres.Split(" ")[0];
                var Primer_Apellido = solicitud.Apellidos.Split(" ")[0];

                var Usuario = new ApplicationUser
                {
                    UserName = $"{Primer_Nombre}_{Primer_Apellido}",
                    Nombres = solicitud.Nombres,
                    Apellidos = solicitud.Apellidos,
                    Cedula = solicitud.Cedula,
                    Telefono = solicitud.Contacto_1,
                    Email = solicitud.Correo,
                    Direccion = solicitud.Direccion,
                    Fecha_Creacion = DateTime.Now,
                    EmailConfirmed = true
                };

                var password = Usuario.Cedula.Replace("-", "");

                var crear_User = userManager.CreateAsync(Usuario, password);
                crear_User.Wait();

                if (crear_User.Result.Succeeded == false)
                {

                    var info_error = crear_User.Result.Errors.FirstOrDefault();
                    
                    return Json(new { title = "Solicitud de Cuenta", text = info_error, icon = "error" });

                }


             

                var asignar_Rol = userManager.AddToRoleAsync(Usuario, "Cliente");
                asignar_Rol.Wait();

                var Cuenta = new Cuenta_Bancaria
                {
                    Fecha_Creacion = DateTime.Now,
                    Tipo_Cuenta = "Debito",
                    Propietario_ID = Usuario.Id,
                    Balance = 2000,
                    Monto_Maximo = 0,
                    Fecha_De_Corte = DateTime.Now.AddDays(30),
                    Fecha_Limite = DateTime.Now,
                    


                };


                db.Cuentas_Bancarias.Add(Cuenta);
                db.SaveChanges();

            }

            solicitud.Cerrada = true;
            solicitud.Fecha_Cierre = DateTime.Now;

            db.SaveChanges();
            return Json(new { title = "Solicitud de Cuenta", text = "Cuenta creada exitósamente", icon = "success" });
        }
        [Authorize(Roles = "Representante,Gerente")]
        public JsonResult Aprobar_Solicitud_Prestamo(int Solicitud_ID)
        {

            var solicitud = db.Solicitudes_Prestamos.Find(Solicitud_ID);

            var valid_User = db.Users.Where(x => x.Cedula == solicitud.Cedula).FirstOrDefault();


            if (valid_User != null)
            {

                var cuenta_usuario = db.Cuentas_Bancarias
                    .Where(x => x.Propietario_ID == valid_User.Id)
                    .Where(x => x.Cerrada == false).FirstOrDefault();

                cuenta_usuario.Balance += solicitud.Monto_Solicitado;

                var Cuenta = new Cuenta_Bancaria
                {
                    Fecha_Creacion = DateTime.Now,
                    Tipo_Cuenta = "Prestamo",
                    Propietario_ID = valid_User.Id,
                    Balance = solicitud.Monto_Solicitado,
                    Monto_Maximo = 0,
                    Fecha_De_Corte = DateTime.Now.AddDays(29),
                    Fecha_Limite = DateTime.Now.AddDays(35)
                    

                };
                

                db.Cuentas_Bancarias.Add(Cuenta);
                db.SaveChanges();

            }
            else
            {
                var Primer_Nombre = solicitud.Nombres.Split(" ")[0];
                var Primer_Apellido = solicitud.Apellidos.Split(" ")[0];

                var Usuario = new ApplicationUser
                {
                    UserName = $"{Primer_Nombre}_{Primer_Apellido}",
                    Nombres = solicitud.Nombres,
                    Apellidos = solicitud.Apellidos,
                    Cedula = solicitud.Cedula,
                    Telefono = solicitud.Contacto_1,
                    Email = solicitud.Correo,
                    Direccion = solicitud.Direccion,
                    Fecha_Creacion = DateTime.Now,
                    EmailConfirmed = true
                };

                var password = Usuario.Cedula.Replace("-", "");

                var crear_User = userManager.CreateAsync(Usuario, password);
                crear_User.Wait();

                if (crear_User.Result.Succeeded == false)
                {

                    var info_error = crear_User.Result.Errors.FirstOrDefault();
                    
                    return Json(new { title = "Solicitud de Cuenta", text = info_error, icon = "error" });

                }


             

                var asignar_Rol = userManager.AddToRoleAsync(Usuario, "Cliente");
                asignar_Rol.Wait();

                var Cuenta = new Cuenta_Bancaria
                {
                    Fecha_Creacion = DateTime.Now,
                    Tipo_Cuenta = "Prestamo",
                    Propietario_ID = Usuario.Id,
                    Balance = solicitud.Monto_Solicitado,
                    Monto_Maximo = 0,
                    Fecha_De_Corte = DateTime.Now.AddDays(29),
                    Fecha_Limite = DateTime.Now.AddDays(35)



                };


                db.Cuentas_Bancarias.Add(Cuenta);
                db.SaveChanges();

            }
            var UserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;

            var Usuario_Login = db.Users.Where(i => i.Id == UserID).AsSingleQuery().FirstOrDefault();
            solicitud.Cerrada = true;
            solicitud.Aprobado = true;
            solicitud.Aprobado_Por = Usuario_Login.Nombres + " " + Usuario_Login.Apellidos;
            solicitud.Fecha_Cierre = DateTime.Now;

            db.SaveChanges();
            return Json(new { title = "Solicitud de Cuenta", text = "Cuenta creada exitósamente", icon = "success" });
        }

        public JsonResult Rechazar_Solicitud_Cuenta(int Solicitud_ID)
        {
            var solicitud = db.Solicitudes_Cuentas.Find(Solicitud_ID);

            //solicitud.Cerrada = true;
            //solicitud.Fecha_Cierre = DateTime.Now.AddHours(3);
            //solicitud.Aprobado = false;
            db.Solicitudes_Cuentas.Remove(solicitud);
            db.SaveChanges();

            return Json(new { title = "Solicitud de Cuenta", text = "Cuenta Rechazada", icon = "success" });
        }

    }
}
