using ERP.Entidades.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Filter
{
    public class FilterSeguridad : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string sessionActual = context.HttpContext.Session.GetString("usuario");
            string menusWeb = context.HttpContext.Session.GetString("menuRol");

            if (sessionActual == null)
            {
                context.Result = new RedirectToActionResult("Index", "Acceso", null);
            }

            SeguridadMenu(context, menusWeb);
        }

        private void SeguridadMenu(ActionExecutingContext context, string menu)
        {
            if (menu != null)
            {
                //Controles y acciones
                List<SPaginasRol> listaMenu = JsonConvert.DeserializeObject<List<SPaginasRol>>(menu);

                string controlador = ((ControllerBase)context.Controller).
                    ControllerContext.ActionDescriptor.ControllerName;

                string accion = ((ControllerBase)context.Controller).
                    ControllerContext.ActionDescriptor.ActionName;

                int contador = listaMenu.FindAll(x => x.Controlador.ToUpper() == controlador.ToUpper() &&
                x.Accion.ToUpper() == accion.ToUpper()).Count;

                if (contador == 0)
                {
                    context.Result = new RedirectToActionResult("Index", "Acceso", null);
                }
            }
        }
    }
}
