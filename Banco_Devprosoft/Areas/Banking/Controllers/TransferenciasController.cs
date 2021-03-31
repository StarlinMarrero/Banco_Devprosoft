using Banco_Devprosoft.Data;
using Banco_Devprosoft.Models;
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

        public JsonResult Verificar_Transferencia(int Cuenta_Destino, int Cuenta_Desde, int Monto)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

           

            var cuenta = db.Cuentas_Bancarias.Where(x => x.Propietario_ID == UserId).Where(x => x.Cuenta_ID == Cuenta_Desde).FirstOrDefault();


            var Validation_Destino = db.Cuentas_Bancarias.Find(Cuenta_Destino);


            if(Validation_Destino == null)
            {
                return Json(new { title = "Transferencias", text = "La cuenta no fué encontrada", icon = "error" });

            }
            if (Validation_Destino.Cerrada == true)
            {
                return Json(new { title = "Transferencias", text = "La cuenta " + Cuenta_Destino + " De este clienta esta cerrada. ", icon = "info" });
            }
            if (Monto > cuenta.Balance)
            {
                return Json(new { title = "Transferencias", text = "Su cuenta posee menos balance del solicitado a transferir.", icon = "error" });

            }
            var user = db.Users.Find(Validation_Destino.Propietario_ID);

            var Nombre_Completo = $"{user.Nombres} {user.Apellidos}";
            return Json(new { Nombre_Completo });
        }

        public JsonResult Realizar_Transferencia(int Cuenta_Destino, int Cuenta_Desde, int Monto)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cuenta_Origen = db.Cuentas_Bancarias.Where(x => x.Propietario_ID == UserId)
                .Where(x => x.Cuenta_ID == Cuenta_Desde)
                .FirstOrDefault();

            var cuenta_Destino = db.Cuentas_Bancarias.Find(Cuenta_Destino);

         

            cuenta_Origen.Balance -= Monto;
            cuenta_Destino.Balance += Monto;

            var model = new Transferencia
            {
                Cuenta_Destino_ID = Cuenta_Destino,
                Cuenta_Origen_ID = cuenta_Origen.Cuenta_ID,
                Fecha_Transaccion = DateTime.Now.AddHours(3).AddHours(3),
                Monto = Monto

            };

            db.Transferencias.Add(model);
            db.SaveChanges();

            return Json(new { title = "Transferencias", text = "Transferencia realizada exitósamente", icon = "success" });
        }

        public JsonResult Obtener_Mis_Transferencias()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transferencias_List = new List<Transferencia>();

            var cuentas = db.Cuentas_Bancarias
                .Where(x => x.Cerrada == false)
                .Where(x => x.Propietario_ID == UserId).ToList();

           //He tenido que hacerlo de esta forma, hay dificultades en los condificionales ||

            foreach (var item in cuentas)
            {
                var lista = db.Transferencias.Where(x => x.Cuenta_Origen_ID == item.Cuenta_ID || x.Cuenta_Destino_ID == item.Cuenta_ID).ToList();

                foreach (var item_list in lista)
                {
                    transferencias_List.Add(item_list);
                }

               
            }


            return Json(transferencias_List);
        }

    }
}
