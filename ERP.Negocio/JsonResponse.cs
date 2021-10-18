using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Negocio
{
    public class JsonResponse
    {
        public string Mensaje { get; set; }
        public string MensajeException { get; set; }
        public object Entidad { get; set; }
        public bool Success { get; set; }
    }
}
