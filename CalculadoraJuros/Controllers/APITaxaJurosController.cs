using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CalculadoraJuros.Controllers
{
    public static class APITaxaJurosController
    {

        private static WebRequest GetWebRequest(IConfiguration configuration)
        {
            string urlApiTaxaJuros = configuration["TaxaJurosAPI"];
            if (string.IsNullOrEmpty(urlApiTaxaJuros)) throw new ApplicationException("API de taxa de juros não definida na configuração!");
            WebRequest request = WebRequest.Create(urlApiTaxaJuros);
            request.Method = "GET";
            return request;
        }

        public static decimal GetTaxaJuros(IConfiguration configuration)
        {
            WebRequest request = GetWebRequest(configuration);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (var readRequest = new System.IO.StreamReader(response.GetResponseStream()))
            {
                string result = readRequest.ReadToEnd();
                var culture = CultureInfo.CreateSpecificCulture("en-US");
                var style = NumberStyles.AllowDecimalPoint;
                if (decimal.TryParse(result, style, culture, out decimal taxaJuros))
                {
                    return taxaJuros;
                }
                throw new ApplicationException("Não foi possível buscar taxa de Juros!");
            }
        }

    }
}
