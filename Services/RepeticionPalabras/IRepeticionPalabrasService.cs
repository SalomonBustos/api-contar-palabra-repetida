using PruebaTecnica.Dtos.RepeticionPalabras;

namespace PruebaTecnica.Services.RepeticionPalabras
{
    public interface IRepeticionPalabrasService
    {
        RepeticionPalabrasResponse ContarCantidadRepeticionesPalabra(RepeticionPalabrasRequest request);
        string Base64Encode(string plainText);
        string Base64Decode(string base64EncodedData);
    }
}