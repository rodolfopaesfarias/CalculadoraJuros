using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxaJurosAPI.Models
{
    public class Juros
    {

        private static decimal PercentualJurosPadrao
        {
            get
            {
                return 1m;
            }
        }

        public static decimal TaxaJurosPadrao
        {
            get
            {
                return PercentualJurosPadrao / 100;
            }
        }

        private decimal Percentual { get; set; }

        public decimal Taxa
        {
            get
            {
                return Percentual / 100;
            }
        }

        public Juros(decimal percentualJuros)
        {
            if (percentualJuros < 0) throw new ArgumentOutOfRangeException("Percentual de juros não pode ser negativo");

            Percentual = percentualJuros;
        }

        /// <summary>
        /// Inicializa taxa de juros com percentual padrão de juros        
        /// </summary>        
        public Juros()
        {
            Percentual = PercentualJurosPadrao;
        }
    }
}
