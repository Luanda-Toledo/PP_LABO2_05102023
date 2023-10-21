using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion resultado;
        private static ESistema sistema;


        static Calculadora()
        {
            Calculadora.sistema = ESistema.Decimal;
        }

        public Calculadora()
        {
            this.operaciones  = new List<string>();
        }

        public Calculadora(string nombreAlumno):this() 
        {
            this.nombreAlumno = nombreAlumno;
        }

        public string NombreAlumno
        {
            get { return nombreAlumno; }
            set { nombreAlumno = value; }
        }

        public List<string> Operaciones
        {
            get { return operaciones; }
        }

        public Numeracion Resultado
        {
            get { return resultado; }
        }

        public Numeracion PrimerOperando
        {
            get { return primerOperando; }
            set { primerOperando = value; }
        }

        public Numeracion SegundoOperando
        {
            get { return segundoOperando; }
            set { segundoOperando = value; }
        }

        public static ESistema Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }

        /// <summary>
        /// Realiza una operación matemática en función del operador especificado y actualiza el resultado.
        /// </summary>
        /// <param name="operador">El operador matemático (+, -, *, /) que se utilizará en la operación.</param>
        public void Calcular(char operador)
        {
            double resultado = double.MinValue;

            if (this.primerOperando == this.segundoOperando)
            {
                switch (operador) 
                {
                    case '-':
                        resultado = this.primerOperando.ValorNumerico - this.segundoOperando.ValorNumerico;
                        break;

                    case '*':
                        resultado = this.primerOperando.ValorNumerico * this.segundoOperando.ValorNumerico;
                        break;

                    case '/':
                        resultado = this.primerOperando.ValorNumerico / this.segundoOperando.ValorNumerico;
                        break;

                    default:
                        resultado = this.primerOperando.ValorNumerico + this.segundoOperando.ValorNumerico;
                        break;
                }
            }

            this.resultado = this.MapeaResultado(resultado);
        }

        /// <summary>
        /// Realiza una operación de suma (por defecto) utilizando los operandos actuales y actualiza el resultado.
        /// </summary>
        public void Calcular()
        {
            this.Calcular('+'); 
        }

        /// <summary>
        /// Realiza un mapeo del valor numérico especificado a una instancia de la clase Numeracion
        /// y cambia su sistema de numeración al sistema actual de la calculadora.
        /// </summary>
        /// <param name="valor">El valor numérico que se mapeará y cambiará de sistema de numeración.</param>
        /// <returns>
        /// Una instancia de la clase Numeracion que representa el valor mapeado al sistema de numeración actual de la calculadora.
        /// </returns>
        private Numeracion MapeaResultado(double valor)
        {
            Numeracion resultado = (SistemaDecimal)valor.ToString();
            return resultado.CambiarSistemaDeNumeracion(Calculadora.sistema);
        }

        /// <summary>
        /// Actualiza el historial de operaciones de la calculadora con la última operación realizada.
        /// </summary>
        /// <param name="operador">El operador matemático (+, -, *, /) utilizado en la operación.</param>
        public void ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder historial = new StringBuilder();
            historial.Append($"[{Calculadora.Sistema}] => {this.primerOperando.Valor} {operador} {this.segundoOperando.Valor} = {this.resultado.Valor}");
            this.operaciones.Add(historial.ToString());
        }

        /// <summary>
        /// Elimina todas las operaciones del historial de la calculadora.
        /// </summary>
        public void EliminarHistorialDeOperaciones()
        {
            this.operaciones.Clear();
        }
    }
}


