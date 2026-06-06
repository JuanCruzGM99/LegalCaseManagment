using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
namespace Services
{
	public class Encriptador
	{
		public string Encriptar(string mensaje)
		{
			string hash = "automark";
			byte [] bytes = Encoding.UTF8.GetBytes(mensaje);
			MD5 md5 = MD5.Create();
			TripleDES tripleDES = TripleDES.Create();
			tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
			tripleDES.Mode = CipherMode.ECB;

			ICryptoTransform transform = tripleDES.CreateEncryptor();
			byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);
			return Convert.ToBase64String(result);
		}
	    public string Desencriptar(string mensajeEncriptado)
		{
			string hash = "automark";
			byte[] bytes = Convert.FromBase64String(mensajeEncriptado);
			MD5 md5 = MD5.Create();
			TripleDES tripleDES = TripleDES.Create();
			tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
			tripleDES.Mode = CipherMode.ECB;

			ICryptoTransform transform = tripleDES.CreateDecryptor();
			byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);
			return UTF8Encoding.UTF8.GetString(result);
		}
	}
}
