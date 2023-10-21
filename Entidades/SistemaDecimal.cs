using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {
        public SistemaDecimal(string valor) : base(valor)
        {
        }

        internal override double ValorNumerico
        {
            get
            {
                return (double)this;
            }
        }

        /// <summary>
        /// Cambia el sistema de numeración de la instancia actual a uno nuevo especificado.
        /// </summary>
        /// <param name="nuevoSistema">El nuevo sistema de numeración al que se desea convertir la instancia.</param>
        /// <returns>Una nueva instancia de la clase Numeracion en el sistema de numeración especificado.</returns>
        public override Numeracion CambiarSistemaDeNumeracion(ESistema nuevoSistema)
        {
            switch (nuevoSistema)
            {
                case ESistema.Binario:
                    return this.DecimalABinario();
                case ESistema.Octal:
                    return this.DecimalAOctal();
                default:
                    return this;
            }
        }

        /// <summary>
        /// Verifica si una cadena es una numeración válida en el sistema de numeración decimal.
        /// </summary>
        /// <param name="valor">La cadena que se va a verificar.</param>
        /// <returns>
        /// True si la cadena es una numeración válida en el sistema de numeración decimal; de lo contrario, False.
        /// La validación se basa en comprobar que la cadena no sea nula o contenga solo espacios en blanco y sea un valor válido en el sistema decimal.
        /// </returns>
        protected override bool EsNumeracionValida(string valor)
        {
           return base.EsNumeracionValida(valor) && this.EsSistemaDecimalValido(valor);
        }

        /// <summary>
        /// Verifica si una cadena es un valor válido en el sistema de numeración decimal.
        /// </summary>
        /// <param name="valor">La cadena que se va a verificar.</param>
        /// <returns>True si la cadena es un valor válido en el sistema de numeración decimal; de lo contrario, False.</returns>
        private bool EsSistemaDecimalValido(string valor)
        {
            return double.TryParse(valor, out double resultado);
        }

        /// <summary>
        /// Convierte el valor numérico de la instancia actual al sistema de numeración binario.
        /// </summary>
        /// <returns>
        /// Una instancia de la clase SistemaBinario que representa el valor numérico convertido al sistema de numeración binario, 
        /// o un mensaje de error en caso de que el valor numérico sea igual a cero.
        /// </returns>
        internal SistemaBinario DecimalABinario()
        {
            int valor = (int)this.ValorNumerico;

            if (valor == 0)
            {
                string binario = string.Empty;
                while (valor > 0)
                {
                    binario = (valor % 2) + binario;
                    valor /= 2;
                }
                return binario;
            }

            return Numeracion.msgError;
        }

        /// <summary>
        /// Convierte el valor numérico de la instancia actual al sistema de numeración octal.
        /// </summary>
        /// <returns>
        /// Una instancia de la clase SistemaOctal que representa el valor numérico convertido al sistema de numeración octal, 
        /// o un mensaje de error en caso de que el valor numérico sea igual a cero.
        /// </returns>
        public SistemaOctal DecimalAOctal()
        {
            int valor = (int)this.ValorNumerico;

            if (valor == 0)
            {
                string octal = string.Empty;
                while (valor > 0)
                {
                    octal = (valor % 8) + octal;
                    valor /= 8;
                }
                return octal;
            }

            return Numeracion.msgError;
        }

        // Conversiónes implicitas
        public static implicit operator SistemaDecimal(double valor) 
        {
            return new SistemaDecimal(valor.ToString());
        }

        public static implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }
    }
}
