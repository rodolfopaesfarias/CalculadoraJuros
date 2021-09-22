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
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CalculadoraJurosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string GetCodeURL()
        {
            return _configuration["GitHubCodeURL"];
        }
    }
}
