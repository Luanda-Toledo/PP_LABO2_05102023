using System;
using System.Drawing;

namespace Entidades
{
    public enum ESistema {Decimal, Binario};

    public abstract class Numeracion
    {
        // Atributos protegidos
        protected string msgError;
        protected string valor;
        protected ESistema sistema;
        private string valorInicial;

        static Numeracion() 
        {
            string msgError = "Numero Invalido";
        }

        // Constructor protegido que llama a inicializaValor
        protected Numeracion(string valorInicial, ESistema sistema)
        {
            this.sistema = sistema;
            InicializaValor(valorInicial);
        }

        protected Numeracion(string valorInicial)
        {
            this.valorInicial = valorInicial;
        }

        public string Valor
        {
            get
            {
                return valor;
            }
        }

        internal abstract double ValorNumerico
        {
            get;
        }

        public ESistema Sistema 
        { 
            get 
            { 
                return sistema; 
            } 
            set 
            { 
                sistema = value; 
            }
        }


        // Inicializar el valor y validar
        private void InicializaValor(string valorInicial)
        {
            if (EsNumeracionValida(valorInicial))
            {
                valor = valorInicial;
            }
            else
            {
                valor = msgError;
            }
        }

        public abstract void CambiarSistemaDeNumeracion(ESistema sistemaSeleccionado);

        /// <summary>
        /// Verifica si la cadena de valor no es nula ni contiene solo espacios en blanco.
        /// </summary>
        /// <returns>true si la cadena es válida sino false.</returns>
        protected bool EsNumeracionValida(string valor)
        {
            if (valor != null)
            {
                bool contieneCaracterNoEspacio = false;

                foreach (char c in valor)
                {
                    if (c != ' ')
                    {
                        contieneCaracterNoEspacio = true;
                        break;
                    }
                }

                return contieneCaracterNoEspacio;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Numeracion numUno, Numeracion numDos)
        {
            if ((object)numUno == null && (object)numDos == null)
            {
                return true; // Ambos son nulos, considerados iguales.
            }

            if ((object)numUno == null || (object)numDos == null)
            {
                return false; // Uno es nulo, el otro no, considerados diferentes.
            }

            return numUno.sistema == numDos.sistema;
        }

        public static bool operator !=(Numeracion numUno, Numeracion numDos)
        {
            return !(numUno == numDos);
        }

        public static explicit operator double(Numeracion num)
        {
            if (double.TryParse(num.valor, out double resultado))
            {
                return resultado;
            }

        }
    }
}