using System.Net.Mime;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Dtos.RepeticionPalabras;
using PruebaTecnica.Services.RepeticionPalabras;

namespace PruebaTecnica.Controllers.RepeticionPalabras
{
    [ApiController]
    [Route("/api/v1/palabras")]
    public class RepeticionPalabrasController : ControllerBase
    {

        private readonly IRepeticionPalabrasService _service;

        public RepeticionPalabrasController(IRepeticionPalabrasService service)
        {
            this._service = service;
        }

        [HttpPost("contarrepeticiones")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ContarCantidadRepeticionesPalabra(RepeticionPalabrasRequest request)
        {
            RepeticionPalabrasResponse response = _service.ContarCantidadRepeticionesPalabra(request);
            string palabra = response.palabra;
            response.palabra = _service.Base64Encode(response.palabra);

            if (response.cantidadRepeticiones > 0)
            {
                if (response.cantidadRepeticiones == 1)
                {
                    return Ok(new ApiResponse(_service.Base64Encode($"La palabra '{palabra}' fue encontrada en en el texto '{response.cantidadRepeticiones}' vez."), response, 200));
                }
                else
                {
                    return Ok(new ApiResponse(_service.Base64Encode($"La palabra '{palabra}' fue encontrada en en el texto '{response.cantidadRepeticiones}' veces."), response, 200));
                }
            }
            else
            {
                return NotFound(new ApiResponse(_service.Base64Encode($"La palabra '{palabra}' no fue encontrada en en el texto."), response, 404));
            }
        }


    }
}