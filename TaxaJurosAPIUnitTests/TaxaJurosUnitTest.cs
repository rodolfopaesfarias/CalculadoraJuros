using System;
using TaxaJurosAPI;
using Xunit;

namespace TaxaJurosAPIUnitTests
{
    public class TaxaJurosUnitTest
    {
        
        [Fact]
        public void IsTaxaJurosIgualTaxaJurosPadrao()
        {
            var taxaJurosController = new TaxaJurosAPI.Controllers.TaxaJurosController();
            decimal taxaJuros = taxaJurosController.GetTaxaJuros();
            Assert.Equal(taxaJuros, TaxaJurosAPI.Models.Juros.TaxaJurosPadrao);
        }
    }
}
