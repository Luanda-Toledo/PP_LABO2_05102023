using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        public SistemaBinario(string valor) : base(valor)
        {
        }

        internal override double ValorNumerico
        {
            get
            {
                return (double)this.CambiarSistemaDeNumeracion(ESistema.Decimal);
            }
        }

        /// <summary>
        /// Cambia el sistema de numeración de la instancia actual a uno nuevo especificado.
        /// </summary>
        /// <param name="nuevoSistema">El nuevo sistema de numeración al que se desea convertir la instancia.</param>
        /// <returns>
        /// Una nueva instancia de la clase Numeracion en el sistema de numeración especificado, 
        /// o la instancia actual sin cambios si se solicita el mismo sistema de numeración.
        /// </returns>
        public override Numeracion CambiarSistemaDeNumeracion(ESistema nuevoSistema)
        {
            switch (nuevoSistema)
            {
                case ESistema.Decimal:
                    return this.BinarioADecimal();
                case ESistema.Octal:
                    return this.BinarioAOctal();
                default:
                    return this;
            }
        }

        /// <summary>
        /// Verifica si una cadena representa una numeración válida en el sistema de numeración binario.
        /// </summary>
        /// <param name="valor">La cadena que se va a verificar.</param>
        /// <returns>
        /// True si la cadena es una numeración válida en el sistema de numeración binario; de lo contrario, False.
        /// La validación se basa en comprobar que la cadena no sea nula o contenga solo espacios en blanco y sea un valor válido en el sistema binario.
        /// </returns>
        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaBinarioValido(valor);
        }

        /// <summary>
        /// Verifica si una cadena es un valor válido en el sistema de numeración binario.
        /// </summary>
        /// <param name="valor">La cadena que se va a verificar.</param>
        /// <returns>
        /// True si la cadena es un valor válido en el sistema de numeración binario; de lo contrario, False.
        /// La validación se basa en comprobar que la cadena contenga solo caracteres '0' y '1'.
        /// </returns>
        private bool EsSistemaBinarioValido(string valor)
        {
            foreach (char c in valor)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte el valor binario de la instancia actual al sistema de numeración decimal.
        /// </summary>
        /// <returns>
        /// Un objeto de la clase SistemaDecimal que representa el valor binario convertido al sistema de numeración decimal,
        /// o un valor especial (double.MinValue) en caso de que la instancia actual contenga un mensaje de error.
        /// </returns>
        private SistemaDecimal BinarioADecimal()
        {
            if (base.valor != Numeracion.msgError)
            {
                int potencia = base.valor.Length - 1;
                int resultado = 0;

                foreach (char c in base.valor)
                {
                    if (c == '1')
                    {
                        resultado = resultado + (int)Math.Pow(2, potencia);
                    }
                    potencia--;
                }
                return resultado;
            }
            return double.MinValue;
        }

        /// <summary>
        /// Convierte el valor binario de la instancia actual al sistema de numeración octal.
        /// </summary>
        /// <returns>
        /// Una instancia de la clase SistemaOctal que representa el valor binario convertido al sistema de numeración octal,
        /// o un mensaje de error en caso de que la instancia actual contenga un valor no válido.
        /// </returns>
        private SistemaOctal BinarioAOctal()
        {
            if (base.valor != Numeracion.msgError)
            {
                // Convierte el valor binario a decimal utilizando el método BinarioADecimal
                SistemaDecimal decimalValue = this.BinarioADecimal();

                // Convierte el valor decimal a octal
                SistemaOctal octal = decimalValue.DecimalAOctal();

                return octal;
            }
            return Numeracion.msgError;
        }

        // Conversión implícita de string a SistemaBinario
        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }
    }
}
