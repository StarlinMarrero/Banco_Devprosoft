using Banco_Devprosoft.Data;
using Banco_Devprosoft.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Controllers
{
    public class PrestamosController : Controller
    {

        private ApplicationDbContext db;

        public PrestamosController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Crear_Solicitud(Solicitud_Prestamo model)
        {
            var valid = db.Solicitudes_Prestamos.Where(x => x.Cedula == model.Cedula).FirstOrDefault();

            if(valid != null)
            {

                return Json(new {title = "Solicitud de Préstamo", text = "Usted ya tiene una solicitud pendiente. Puede visitar nuestras oficinas para consultar su estado.", icon = "info" });
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
