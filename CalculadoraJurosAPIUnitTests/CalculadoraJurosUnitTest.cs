using CalculadoraJuros.Models;
using System;
using TaxaJurosAPI.Models;
using Xunit;

namespace CalculadoraJurosAPIUnitTests
{
    public class CalculadoraJurosUnitTest
    {
        
        /// <summary>
        /// Testa se o valor ficará correto numa requisição normal
        /// </summary>
        [Fact]
        public void IsValorFinalCorretoComPeriodoMaximo()
        {
            decimal valorInicial = 1250000M;
            decimal taxaJurosPadrao = Juros.TaxaJurosPadrao;
            int tempoEmMeses = 1200;
            decimal valorFinalEsperado = 191671946006.91M;
            decimal valorFinalCalculado = CalculadoraJurosCompostos.GetValorFinal(valorInicial, taxaJurosPadrao, tempoEmMeses);
            Assert.Equal(valorFinalCalculado, valorFinalEsperado);
        }

        /// <summary>
        /// Testa se o valor final ficará igual ao inicial caso o tempo em meses seja zero
        /// </summary>
        [Fact]        
        public void IsValorFinalCorretoComPeriodoZero()
        {
            decimal valorInicial = 1250000M;
            decimal taxaJurosPadrao = Juros.TaxaJurosPadrao;
            int tempoEmMeses = 0;
            decimal valorFinalCalculado = CalculadoraJurosCompostos.GetValorFinal(valorInicial, taxaJurosPadrao, tempoEmMeses);
            Assert.Equal(valorFinalCalculado, valorInicial);
        }

        /// <summary>
        /// Testa se o valor final ficará igual ao inicial se a taxa de juros for zero
        /// </summary>
        [Fact]
        public void IsValorFinalCorretoComTaxaZero()
        {
            decimal valorInicial = 1250000M;
            decimal taxaJurosPadrao = 0;
            int tempoEmMeses = CalculadoraJurosCompostos.LimiteMaximoMeses;
            decimal valorFinalCalculado = CalculadoraJurosCompostos.GetValorFinal(valorInicial, taxaJurosPadrao, tempoEmMeses);
            Assert.Equal(valorFinalCalculado, valorInicial);
        }

        /// <summary>
        /// Testa se ocorre erro de argument out of range exception caso tempo em meses seja negativo
        /// </summary>
        [Fact]
        public void ErroSePeriodoMenorQueZero()
        {
            decimal valorInicial = 1250000M;
            decimal taxaJurosPadrao = Juros.TaxaJurosPadrao;
            int tempoEmMeses = -1;
            Assert.Throws<ArgumentOutOfRangeException>(()
                => CalculadoraJurosCompostos.GetValorFinal(valorInicial, taxaJurosPadrao, tempoEmMeses));
        }

        /// <summary>
        /// Testa se ocorre erro de argument out of range caso o tempo em meses seja maior que 1200 meses
        /// (100 anos)
        /// </summary>
        [Fact]        
        public void ErroSePeriodoMaiorQueLimiteMaximo()
        {
            decimal valorInicial = 1250000M;
            decimal taxaJurosPadrao = Juros.TaxaJurosPadrao;
            int tempoEmMeses = 1201;
            Assert.Throws<ArgumentOutOfRangeException>(()
                => CalculadoraJurosCompostos.GetValorFinal(valorInicial, taxaJurosPadrao, tempoEmMeses));
        }
    }
}
