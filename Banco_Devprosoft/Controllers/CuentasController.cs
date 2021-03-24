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
            return Json(new { title = "Solicitud de Cuentas", text = "Su Solicitud ha sido enviada", icon = "success"});
        }


    }
}
