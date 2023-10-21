using System;
using System.Drawing;

namespace Entidades
{
    public abstract class Numeracion
    {
        // Atributos
        protected static string msgError;
        protected string valor;

        static Numeracion()
        {
            Numeracion.msgError = "Numero Invalido";
        }

        protected Numeracion(string valor)
        {
            this.InicializaValor(valor);
        }

        public string Valor
        {
            get { return this.valor; }
        }

        internal abstract double ValorNumerico
        {
            get;
        }

        /// <summary>
        /// Da un estado inicial al atributo valor
        /// Si el valor proporcionado es válido, se asigna a la propiedad "valor". 
        /// Si el valor no es válido, se asigna un mensaje de error predeterminado.
        /// </summary>
        /// <param name="valor">El valor que se va a asignar a la propiedad "valor". Debe ser una numeración válida.</param>
        private void InicializaValor(string valor)
        {
            if (this.EsNumeracionValida(valor))
            {
                this.valor = valor;
            }
            else
            {
                this.valor = Numeracion.msgError;
            }
        }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistemaSeleccionado);

        /// <summary>
        /// Verifica si una cadena no es nula ni contiene solo espacios en blanco.
        /// </summary>
        /// <param name="valor">La cadena que se va a verificar.</param>
        /// <returns>True si la cadena no es nula y contiene al menos un carácter diferente de un espacio en blanco; de lo contrario, False.</returns>        
        protected virtual bool EsNumeracionValida(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor);
        }

        public static bool operator ==(Numeracion numUno, Numeracion numDos)
        {
            return numUno is not null && numDos is not null && numUno.GetType() == numDos.GetType();
        }

        public static bool operator !=(Numeracion numUno, Numeracion numDos)
        {
            return !(numUno == numDos);
        }

        public static explicit operator double(Numeracion num)
        {
            double.TryParse(num.valor, out double resultado);
            return resultado;
        }
    }
}