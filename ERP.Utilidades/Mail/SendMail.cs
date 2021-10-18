using ERP.Entidades.Correo;
using System;
using System.Net;
using System.Net.Mail;

namespace ERP.Utilidades.Mail
{
    public class SendMail : ISendMail
    {
        public void Send(EnvioCorreo envio)
        {
            try
            {
                MailMessage oMailMessage = new MailMessage(envio.Remitente, envio.Destinatario, envio.Asunto, envio.Mensaje);

                oMailMessage.IsBodyHtml = true;

                SmtpClient oSmtpClient = new SmtpClient("");
                oSmtpClient.EnableSsl = true;
                oSmtpClient.UseDefaultCredentials = false;
                oSmtpClient.Host = "";
                oSmtpClient.Port = 587;
                oSmtpClient.Credentials = new NetworkCredential(envio.Remitente, "");

                oSmtpClient.Send(oMailMessage);

                oSmtpClient.Dispose();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
