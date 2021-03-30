using Banco_Devprosoft.Data;
using Banco_Devprosoft.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Controllers
{
    [AllowAnonymous]
    public class SolicitudesController : Controller
    {

        private ApplicationDbContext db;

        public SolicitudesController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IActionResult Solicitar_Cuenta()
        {
            return View();
        }

        public IActionResult Solicitar_Prestamo()
        {
            return View();
        }

        public JsonResult add_Solicitud_Cuentas(Solicitud_Cuenta model)
        {
            var validacion = db.Solicitudes_Cuentas.Where(p => p.Cedula == model.Cedula).FirstOrDefault();

            if (validacion != null)
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

            return Json(new { title = "Solicitud de Cuentas", text = "Su Solicitud ha sido enviada", icon = "success" });
        }

        public JsonResult Crear_Cuenta_OldUser(string Tipo_Cuenta, string Cedula_recibida)
        {

            var user = db.Users.Where(x => x.Cedula == Cedula_recibida).FirstOrDefault();
            var Get_Cuenta = db.Solicitudes_Cuentas
                 .Where(x => x.Cerrada == false)
                .Where(x => x.Cedula == Cedula_recibida).FirstOrDefault();

            if (Get_Cuenta != null)
            {
                return Json(new { title = "Solicitud de Cuentas", text = "Usted ya tiene una solicitud pendiente, favor espere ser aprobada por el banco.", icon = "info" });

            }

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

        public JsonResult Crear_Solicitud(Solicitud_Prestamo model)
        {
            var valid = db.Solicitudes_Prestamos
                .Where(x => x.Cedula == model.Cedula)
                .Where(x => x.Cerrada == false)
                .FirstOrDefault();

            if (valid != null)
            {

                return Json(new { title = "Solicitud de Préstamo", text = "Usted ya tiene una solicitud pendiente. Puede visitar nuestras oficinas para consultar su estado.", icon = "info" });
            }


            var Model_Solicitud = new Solicitud_Prestamo
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Contacto_1 = model.Contacto_1,
                Contacto_2 = model.Contacto_2,
                Correo = model.Correo,
                Aprobado = false,
                Salario = model.Salario,
                Cedula = model.Cedula,
                Ocupacion = model.Ocupacion,
                Empresa = model.Empresa,
                Fecha_Solicitud = DateTime.Now,
                Empleado = model.Empleado,
                Monto_Solicitado = model.Monto_Solicitado,
                Plazo_Solicitado = model.Plazo_Solicitado
            };
            db.Solicitudes_Prestamos.Add(Model_Solicitud);
            db.SaveChanges();

            return Json(new { title = "Solicitud de Préstamo", text = "Solicitud Enviada, favor espere ser contactado", icon = "success" });
        }

    }
}
