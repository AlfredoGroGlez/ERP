using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entidades.Correo
{
    public class EnvioCorreo
    {
        public string Destinatario { get; set; }
        public string Remitente { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }
}
