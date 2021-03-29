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
    public class TransferenciasController : Controller
    {
        private readonly ApplicationDbContext db;

        public TransferenciasController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Mis_Transferencias()
        {
            return View();
        }

        public JsonResult Realizar_Transferencia(int Cuenta_Destino, int Monto)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cuenta = db.Cuentas_Bancarias.Where(x => x.Propietario_ID == UserId).FirstOrDefault();

            var Validation_Destino = db.Cuentas_Bancarias.Find(Cuenta_Destino);

            if(Validation_Destino == null)
            {
                return Json(new {  });

            }

            if (Monto >= cuenta.Balance)
            {
                return Json("");

            }

            return Json("");
        }

    }
}
