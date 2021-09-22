using CalculadoraJuros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraJuros.Controllers
{
    
    [ApiController]
    [Route("calculajuros")]
    public class CalculadoraJurosController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CalculadoraJurosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Calcula valor final aplicado juros compostos
        /// Taxa de juros é proveniente de API taxaJuros
        /// </summary>
        /// <param name="valorInicial">Valor base para o cálculo</param>
        /// <param name="tempoEmMeses">Tempo em meses para o cálculo de juros (deve estar entre 0 e 1200)</param>
        /// <returns></returns>
        [HttpGet]
        public decimal GetValorComJuros([FromQuery] decimal valorInicial, [FromQuery] int tempoEmMeses)
        {
            decimal taxaJuros = APITaxaJurosController.GetTaxaJuros(_configuration);
            return CalculadoraJurosCompostos.GetValorFinal(valorInicial, taxaJuros, tempoEmMeses);
        }
    }
}
