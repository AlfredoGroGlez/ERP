using ERP.AccesoDatos.Models;
using ERP.AccesoDatos.Repository;
using ERP.Entidades.Seguridad;
using ERP.Negocio.Login.Interfaces;
using ERP.Utilidades.Encryption;
using ERP.Utilidades.Mail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ERP.Negocio.Login
{
    public class LnLogin : ILnLogin
    {
        private readonly IUnitOfWork _LoginWork;
        private readonly IEncryption _Encryption;
        private readonly ISendMail _sendMail;

        public LnLogin(IUnitOfWork loginWork, IEncryption encryption, ISendMail sendMail)
        {
            _LoginWork = loginWork;
            _Encryption = encryption;
            _sendMail = sendMail;
        }

        public string PaginasMenuRol(int idRol)
        {
            List<SPaginasRol> menuConsultado = _LoginWork.Login.PaginasMenuRol(idRol);

            return JsonConvert.SerializeObject(menuConsultado);
        }

        public JsonResponse RecuperaContrasena(string usuario)
        {
            JsonResponse response = null;
            try
            {
                SegUsuario segUsuario = _LoginWork.Login.RecuperaContrasena(usuario);
                string contrasenaRecuperada = _Encryption.Decrypt(segUsuario.Contrasena);
               // _sendMail.Send();

                response = new()
                {
                    Success = true,
                    Mensaje = "",
                    Entidad = contrasenaRecuperada,
                };
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Success = false,
                    MensajeException = ex.Message,
                };
            }

            return response;
        }

        public SUsuario ValidaUsuario(SUsuario usuario)
        {
            SUsuario usuarioValido = null;
            try
            {
                string contrasenaEncriptada = _Encryption.Encrypt(usuario.Contrasena);
                SegUsuario usuarioConsultado = _LoginWork.Login.ValidaUsuario(usuario.Usuario.ToUpper(), contrasenaEncriptada);

                if (usuarioConsultado != null)
                {
                    usuarioValido = new()
                    {
                        Id = usuarioConsultado.Id,
                        Nombre = usuarioConsultado.Nombre,
                        IdRol = usuarioConsultado.IdRol,
                    };
                }
            }
            catch (Exception ex)
            {
            }

            return usuarioValido;
        }
    }
}
