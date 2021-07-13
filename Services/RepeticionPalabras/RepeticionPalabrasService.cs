using System.Text.RegularExpressions;
using PruebaTecnica.Dtos.RepeticionPalabras;

namespace PruebaTecnica.Services.RepeticionPalabras
{
    public class RepeticionPalabrasService : IRepeticionPalabrasService
    {
        public RepeticionPalabrasResponse ContarCantidadRepeticionesPalabra(RepeticionPalabrasRequest request)
        {
            RepeticionPalabrasResponse result = new RepeticionPalabrasResponse();
            string cadenaEvaluando = "";
            result.cantidadRepeticiones = 0;

            request.texto = ReemplazarPuntosAndComas(Base64Decode(request.texto).ToUpper());
            request.palabra = ReemplazarPuntosAndComas(Base64Decode(request.palabra).ToUpper());
            result.palabra = request.palabra;

            for (int i = 0; i < request.texto.Length; i++)
            {
                char caracter = request.texto[i];
                cadenaEvaluando = cadenaEvaluando + caracter;

                if (cadenaEvaluando.Contains(request.palabra))
                {
                    result.cantidadRepeticiones++;
                    cadenaEvaluando = "";
                }
            }

            return result;
        }

        private string ReemplazarPuntosAndComas(string texto)
        {
            return Regex.Replace(texto, @"[,.]", "");
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}