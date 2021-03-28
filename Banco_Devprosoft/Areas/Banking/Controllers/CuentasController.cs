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
    public class CuentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
