using ERP.Entidades.Seguridad;
using ERP.Negocio;
using ERP.Negocio.Login.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ERP.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ILnLogin _LnLogin;

        public AccesoController(ILnLogin lnLogin)
        {
            _LnLogin = lnLogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contrasena()
        {
            return View();
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Remove("usuario");
            HttpContext.Session.Remove("menuRol");

            return RedirectToAction("Index", "Acceso", null);
        }

        public JsonResult AutenticaUsuario([FromBody] SUsuario usuario)
        {
            SUsuario usuarioValidado = _LnLogin.ValidaUsuario(usuario);

            if (usuarioValidado != null)
            {
                string usuarioCadena = JsonConvert.SerializeObject(usuarioValidado);
                HttpContext.Session.SetString("usuario", usuarioCadena);


                string menuRol = _LnLogin.PaginasMenuRol(usuarioValidado.IdRol);
                HttpContext.Session.SetString("menuRol", menuRol);
            }
            else
            {
                HttpContext.Session.Remove("usuario");
                HttpContext.Session.Remove("menuRol");
            }

            return Json(usuarioValidado);
        }

        [HttpPost]
        public JsonResult RecuperaContrasena(string usuario)
        {
            JsonResponse response = _LnLogin.RecuperaContrasena(usuario);
            return Json(response);
        }

    }
}
