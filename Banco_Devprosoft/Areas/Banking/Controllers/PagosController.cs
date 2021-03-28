using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Areas.Banking.Controllers
{
    [Area("Banking")]
    public class PagosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
