using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraJuros.Models
{
    /// <summary>
    /// Responsável por calcular juros compostos baseado no valor inicial, taxa de juros e tempo em meses    
    /// </summary>
    public static class CalculadoraJurosCompostos
    {       

        /// <summary>
        /// Calcula valor final do montante aplicado juros compostos
        /// </summary>
        /// <param name="valorInicial">Valor base para o cálculo</param>
        /// <param name="taxaJuros">Taxa de juros (Exemplo: para 1%, passar 0.01)</param>
        /// <param name="tempoEmMeses">Número de meses para cálculo, valor deve estar entre 0 e 1200 (100 anos)</param>
        /// <returns></returns>
        public static decimal GetValorFinal(decimal valorInicial, decimal taxaJuros, int tempoEmMeses)
        {
            if (tempoEmMeses > 1200 || tempoEmMeses < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tempoEmMeses),
                    tempoEmMeses,
                    "Número de meses deve ser maior ou igual a zero e menor ou igual a 1200.");
            }
            
            double coeficienteJuros = Math.Pow(1 + (double)taxaJuros, tempoEmMeses);
            decimal valorFinal = valorInicial * (decimal)coeficienteJuros;
            return Math.Truncate(valorFinal * 100) / 100;
        }
    }
}
