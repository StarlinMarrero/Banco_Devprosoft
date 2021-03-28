using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Area("Banking")]
    public class UsuariosController : Controller
    {
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
