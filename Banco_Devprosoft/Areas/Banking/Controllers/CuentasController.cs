using Banco_Devprosoft.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Authorize]
    [Area("Banking")]
    public class CuentasController : Controller
    {
        private readonly ApplicationDbContext db;

        public CuentasController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Obtener_Info_Cuentas()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cuenta = db.Cuentas_Bancarias.Where(x => x.Propietario_ID == UserId)
                  .Where(x => x.Cerrada == false)
                .ToList();

            foreach (var item in cuenta)
            {
                if (item.Balance <= 0)
                {
                    item.Cerrada = true;
                    db.SaveChanges();
                }
            }

           return Json(new { cuenta = cuenta });

           
          

        } 
        
        public JsonResult Obtener_Info_Cuentas_A_Pagar()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cuenta = db.Cuentas_Bancarias
                .Where(x => x.Tipo_Cuenta == "Prestamo" || x.Tipo_Cuenta == "Credito" ||
                x.Tipo_Cuenta == "Débito"
                ).Where(x => x.Propietario_ID == UserId)
                .Where(x => x.Cerrada == false)
                //Falta poner bool aprobado
                .ToList();

            foreach (var item in cuenta)
            {
                if (item.Balance <= 0)
                {
                    item.Cerrada = true;
                    db.SaveChanges();
                }
            }

            return Json(new { cuenta = cuenta });

           
          

        }  
        
        public JsonResult Obtener_Info_Cuentas_Desde_A_Pagar()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cuenta = db.Cuentas_Bancarias
                .Where(x => x.Tipo_Cuenta != "Prestamo"
                ).Where(x => x.Propietario_ID == UserId)
                  .Where(x => x.Cerrada == false).ToList();

          

            return Json(new { cuenta = cuenta });

           
          

        }
    }
}
