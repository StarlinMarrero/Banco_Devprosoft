using Banco_Devprosoft.Data;
using Banco_Devprosoft.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public JsonResult Obtener_Pagos()
        {

            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cuentas = db.Cuentas_Bancarias
                .Where(x => x.Propietario_ID == UserId && x.Tipo_Cuenta == "Débito" || x.Tipo_Cuenta == "Crédito")

                //Falta poner bool aprobado
                .ToList();

            var PagosList = new List<Pago>();

            foreach (var item in cuentas)
            {
                var pagos = db.Pagos.Where(x => x.Cuenta_Origen_ID == item.Cuenta_ID).ToList();

                if(pagos != null)
                {

                    foreach (var pago in pagos)
                    {

                        PagosList.Add(pago);

                    }

                }

            }


            return Json(new { PagosList });
        }
    }
}
