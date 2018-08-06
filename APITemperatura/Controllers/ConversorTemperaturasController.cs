using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;

namespace APITemperatura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversorTemperaturasController : ControllerBase
    {
        [HttpGet("Fahrenheit/{temperatura}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Temperatura), (int)HttpStatusCode.OK)]
        public ActionResult<Temperatura> GetConversaoFahrenheit(double temperatura)
        {
            if (temperatura < -459.67)
            {
                return BadRequest(
                    new { Mensagem = "Temperatura inválida na escala Fahrenheit!" });
            }

            Temperatura dados = new Temperatura();
            dados.ValorFahrenheit = temperatura;
            dados.ValorCelsius =
                Math.Round((temperatura - 32.0) / 1.8, 2);
            dados.ValorKelvin = dados.ValorCelsius + 273.15;

            return dados;
        }

        [HttpGet("Celsius/{temperatura}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Temperatura), (int)HttpStatusCode.OK)]
        public ActionResult<Temperatura> GetConversaoCelsius(double temperatura)
        {
            if (temperatura < -273.15)
            {
                return BadRequest(
                    new { Mensagem = "Temperatura inválida na escala Celsius!" });
            }

            Temperatura dados = new Temperatura();
            dados.ValorCelsius = temperatura;
            dados.ValorFahrenheit =
                Math.Round((1.8 * temperatura) + 32.0, 2);
            dados.ValorKelvin = dados.ValorCelsius + 273.15;

            return dados;
        }
    }
}