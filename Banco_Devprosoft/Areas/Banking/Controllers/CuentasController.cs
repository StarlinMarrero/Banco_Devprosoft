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

            var cuenta = db.Cuentas_Bancarias.Where(x => x.Propietario_ID == UserId).FirstOrDefault();

            if(cuenta != null){

                return Json(new { cuenta = cuenta });

            }
            else
            {
                return Json("No tiene Cuenta");

            }

        }
    }
}
