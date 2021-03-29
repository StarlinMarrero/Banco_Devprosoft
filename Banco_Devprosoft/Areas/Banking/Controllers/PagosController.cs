using Banco_Devprosoft.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Authorize]
    [Area("Banking")]
    public class PagosController : Controller
    {
        private readonly ApplicationDbContext db;

        public PagosController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Procesar_Pago(int Cuenta_A_Pagar_Id, int Cuenta_Debitar_Id, int Monto)
        {
            var cuenta_Pagar = db.Cuentas_Bancarias.Find(Cuenta_A_Pagar_Id);
            var cuenta_Debitar = db.Cuentas_Bancarias.Find(Cuenta_Debitar_Id);

            if (cuenta_Debitar.Balance < Monto)
            {
                return Json(new { title = "Pago de cuenta", text = "No tienes saldo suficiente para pagar esta cuenta", icon = "info" });
            }
            if (cuenta_Pagar.Balance < Monto)
            {
                return Json(new { title = "Pago de cuenta", text = "Estás excediendo el pago de esta cuenta, ponga el pago justo", icon = "info" });

            }


            cuenta_Debitar.Balance = cuenta_Debitar.Balance - Monto;

            cuenta_Pagar.Balance = cuenta_Pagar.Balance - Monto;




            db.SaveChanges();

            return Json(new { title = "Pago de cuenta", text = "El pago ha sido procesado.", icon = "success" });
        }

    }
}
