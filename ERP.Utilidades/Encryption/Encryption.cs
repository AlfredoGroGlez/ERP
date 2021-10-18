using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utilidades.Encryption
{
    public class Encryption : IEncryption
    {
        public string Encrypt(string cadena)
        {
            byte[] llaveArreglo;
            byte[] encriptacion = UTF8Encoding.UTF8.GetBytes(cadena);
            string llave = "672567099091267457329888";

            llaveArreglo = UTF8Encoding.UTF8.GetBytes(llave);

            TripleDESCryptoServiceProvider tripleDES = new();

            tripleDES.Key = llaveArreglo;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;

            ICryptoTransform crypto = tripleDES.CreateEncryptor();

            byte[] resultado = crypto.TransformFinalBlock(encriptacion, 0, encriptacion.Length);
            tripleDES.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }

        public string Decrypt(string cadenaEncriptada)
        {
            byte[] llaveArreglo;
            byte[] encriptacion = Convert.FromBase64String(cadenaEncriptada);
            string llave = "672567099091267457329888";

            llaveArreglo = UTF8Encoding.UTF8.GetBytes(llave);

            TripleDESCryptoServiceProvider tripleDES = new();

            tripleDES.Key = llaveArreglo;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;

            ICryptoTransform crypto = tripleDES.CreateDecryptor();

            byte[] resultado = crypto.TransformFinalBlock(encriptacion, 0, encriptacion.Length);
            tripleDES.Clear();

            return UTF8Encoding.UTF8.GetString(resultado);
        }
    }
}
