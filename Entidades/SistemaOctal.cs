using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaOctal : Numeracion
    {
        public SistemaOctal(string valor) : base(valor)
        {
        }

        internal override double ValorNumerico
        {
            get
            {
                return (double)this.CambiarSistemaDeNumeracion(ESistema.Octal);
            }
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema nuevoSistema)
        {
            switch (nuevoSistema)
            {
                case ESistema.Decimal:
                    return this.OctalADecimal();
                case ESistema.Binario:
                    return this.OctalABinario();
                default:
                    return this;
            }
        }

        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaOctalValido(valor);
        }

        private bool EsSistemaOctalValido(string valor)
        {

            foreach (char c in valor)
            {
                string item = c.ToString();
                if (int.TryParse(item, out int numero))
                {
                    return false;
                }

                if(numero > 0 && numero < 8)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Convierte un número octal almacenado como una cadena en un objeto de tipo SistemaDecimal.
        /// </summary>
        /// <returns>Un objeto SistemaDecimal con el valor decimal calculado a partir del número octal.</returns>
        private SistemaDecimal OctalADecimal()
        {
            string numeroOctal = this.ValorNumerico.ToString(); 

            int decimalResult = 0;
            int longitud = numeroOctal.Length;

            // Itera a través de cada dígito en la cadena del número octal.
            for (int i = 0; i < longitud; i++)
            {
                char digitoOctalChar = numeroOctal[i];
                // Convierte el carácter a su valor numérico.
                int digitoOctal = (int)(digitoOctalChar - '0');

                // Calcula el valor decimal sumando el producto del dígito octal y la potencia de 8.
                decimalResult += digitoOctal * (int)Math.Pow(8, longitud - i - 1);
            }

            return new SistemaDecimal(decimalResult.ToString());
        }

        /// <summary>
        /// Convierte un número octal almacenado en la instancia actual en un objeto de tipo SistemaBinario.
        /// </summary>
        /// <returns>Un objeto SistemaBinario que representa el valor binario equivalente del número octal.</returns>
        private SistemaBinario OctalABinario()
        {
            SistemaDecimal valorDecimal = this.OctalADecimal();

            SistemaBinario valorBinario = valorDecimal.DecimalABinario();

            return valorBinario;
        }

        public static implicit operator SistemaOctal(string valor)
        {
            return new SistemaOctal(valor);
        }
    }
}
