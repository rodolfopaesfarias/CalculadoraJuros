using System;
using TaxaJurosAPI;
using Xunit;

namespace TaxaJurosAPIUnitTests
{
    public class TaxaJurosUnitTests
    {
        [Fact]
        public void TestTaxaJurosAPI()
        {
            var taxaJurosController = new TaxaJurosAPI.Controllers.TaxaJurosController();
            decimal taxaJuros = taxaJurosController.GetTaxaJuros();
            Assert.True(taxaJuros == TaxaJurosAPI.Models.Juros.TaxaJurosPadrao);
        }
    }
}
