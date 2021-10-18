using ERP.Entidades.Correo;

namespace ERP.Utilidades.Mail
{
    public interface ISendMail
    {
        void Send(EnvioCorreo envio);
    }
}
