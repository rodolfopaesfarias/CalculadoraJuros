using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxaJurosAPI.Models;

namespace TaxaJurosAPI.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna a taxa de juros padrão para cálculo do valor de juros (Para 1% de juros retornará 0.01)
        /// </summary>        
        [HttpGet]        
        public decimal GetTaxaJuros()
        {
            var juros = new Juros();
            return juros.Taxa;
        }
    }
}
