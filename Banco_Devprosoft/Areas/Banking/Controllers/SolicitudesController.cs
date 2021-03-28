using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Authorize(Roles = "Representante")]
    public class SolicitudesController : Controller
    {
        public IActionResult Solicitudes_Pendientes()
        {
            return View();
        }

        public JsonResult Get_Solicitudes()
        {

            return Json("");
        }
    }
}
