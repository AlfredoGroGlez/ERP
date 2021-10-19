using ERP.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers.Clientes
{
    public class ClientesController : Controller
    {
        [ServiceFilter(typeof(FilterSeguridad))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
