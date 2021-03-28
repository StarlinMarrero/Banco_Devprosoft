using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco_Devprosoft.Data;
using Microsoft.AspNetCore.Identity;
using Banco_Devprosoft.Models;

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



            return Json("");
        }
    }
}
