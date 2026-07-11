using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class DigitoVerificador
    {
        public int CalcularDVHUsuario(string nombreUsuario, string passwordEncriptada)
        {
            string texto = Normalizar(nombreUsuario) + Normalizar(passwordEncriptada);
            return CalcularPorSumaAscii(texto);
        }

        public int CalcularDVV(IEnumerable<int> digitosHorizontales)
        {
            if (digitosHorizontales == null)
                return 0;

            return digitosHorizontales.Sum();
        }

        public bool ValidarDVHUsuario(string nombreUsuario, string passwordEncriptada, int dvhPersistido)
        {
            int dvhCalculado = CalcularDVHUsuario(nombreUsuario, passwordEncriptada);
            return dvhCalculado == dvhPersistido;
        }

        private int CalcularPorSumaAscii(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return 0;

            int resultado = 0;

            foreach (char caracter in texto)
            {
                resultado += Convert.ToInt32(caracter);
            }

            return resultado;
        }

        private string Normalizar(string valor)
        {
            return (valor ?? string.Empty).Trim();
        }
    }
}
