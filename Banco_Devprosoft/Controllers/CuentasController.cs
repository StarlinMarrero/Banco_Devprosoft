using Banco_Devprosoft.Models;
using Banco_Devprosoft.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Controllers
{
  
    public class CuentasController : Controller
    {
        private ApplicationDbContext db;

        public CuentasController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solicitar_Cuenta()
        {
            return View();
        }

        public JsonResult add_Solicitud_Cuentas(Solicitud_Cuenta model)
        {
            var validacion = db.Solicitudes_Cuentas.Where(p => p.Cedula == model.Cedula).FirstOrDefault();

            if(validacion != null)
            {
                return Json(new { title = "Solicitud de Cuentas", text = "Usted ya tiene una solicitud pendiente. Puede visitar nuestras oficinas para consultar su estado.", icon = "info" });

            }

            var Solicitud = new Solicitud_Cuenta
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Salario = model.Salario,
                Cedula = model.Cedula,
                Contacto_1 = model.Contacto_1,
                Contacto_2 = model.Contacto_2,
                Correo = model.Correo,
                Empleado = model.Empleado,
                Tipo_De_Cuenta = model.Tipo_De_Cuenta,
                Empresa = model.Empresa,
                Fecha_Solicitud = DateTime.Now,
                Ocupacion = model.Ocupacion,
            };

            db.Solicitudes_Cuentas.Add(Solicitud);
            db.SaveChanges();

            return Json(new { title = "Solicitud de Cuentas", text = "Su Solicitud ha sido enviada", icon = "success"});
        }

        public JsonResult Crear_Cuenta_OldUser(string Tipo_Cuenta, string Cedula_recibida)
        {

            var user = db.Users.Where(x => x.Cedula == Cedula_recibida).FirstOrDefault();


            if (user == null)
            {
                return Json(new { title = "Solicitud de Cuentas", text = "Usuario no encontrado, favor verificar cédula.", icon = "error" });

            }
        
            var Solicitud = new Solicitud_Cuenta
            {
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Salario = user.Sueldo,
                Cedula = user.Cedula,
                Contacto_1 = user.Contacto_1,
                Contacto_2 = user.Contacto_2,
                Correo = user.Email,
                Empleado = user.Trabaja,
                Tipo_De_Cuenta = Tipo_Cuenta,
                Empresa = user.Empresa,
                Fecha_Solicitud = DateTime.Now,
                Ocupacion = user.Ocupacion
            };



            db.Solicitudes_Cuentas.Add(Solicitud);
            db.SaveChanges();


            return Json(new { title = "Solicitud de Cuentas", text = "Su Solicitud ha sido enviada", icon = "success" });
        }

    }
}
