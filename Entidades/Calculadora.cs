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
        private static ESistema sistema = ESistema.Decimal;
        private char v;
        private char operador;

        public string NombreAlumno
        {
            get 
            {
                return nombreAlumno; 
            }
            set 
            {
                nombreAlumno = value;
            }
        }

        public List<string> Operaciones
        {
            get 
            {
                return operaciones;
            }
        }

        public Numeracion Resultado
        {
            get
            {
                return resultado;
            }
        }

        public Numeracion PrimerOperando
        {
            get
            {
                return primerOperando;
            }
            set
            {
                primerOperando = value;
            }
        }

        public Numeracion SegundoOperando
        {
            get
            {
                return segundoOperando;
            }
            set
            {
                segundoOperando = value;
            }
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

        public Calculadora(Numeracion primerOperando, Numeracion segundoOperando, Numeracion resultado)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
            this.resultado = resultado;
        }

        public Calculadora()
        {
            operaciones = new List<string>();
        }

        public Calculadora(string nombreAlumno) : this()
        {
            this.nombreAlumno = nombreAlumno;
        }

        public Calculadora(char v, char operador)
        {
            this.v = v;
            this.operador = operador;
        }

        public void AsignarOperandos(Numeracion operandoUno, Numeracion operandoDos)
        {
            primerOperando = operandoUno;
            segundoOperando = operandoDos;
        }

        public void Calcular(char operador)
        {
            if (primerOperando != null && segundoOperando != null)
            {
                if (primerOperando.Sistema == segundoOperando.Sistema)
                {
                    switch (operador)
                    {
                        case '+':
                            resultado = primerOperando + segundoOperando;
                            break;
                        case '-':
                            resultado = primerOperando - segundoOperando;
                            break;
                        case '*':
                            resultado = primerOperando * segundoOperando;
                            break;
                        case '/':
                            resultado = primerOperando / segundoOperando;
                            break;
                        default:
                            resultado = primerOperando + segundoOperando;
                            break;
                    }
                }
                else
                {
                    resultado = new SistemaDecimal(double.MinValue.ToString());
                }
            }
            else
            {
                resultado = new SistemaDecimal(double.MinValue.ToString());
            }

            string historial = ActualizaHistorialDeOperaciones(operador);
            operaciones.Add(historial);
        }

        public void Calcular()
        {
            Calcular('+'); 
        }

        public Numeracion MapeaResultado()
        {
            switch (sistema)
            {
                case ESistema.Decimal:
                    return new SistemaDecimal(resultado.Valor);
                case ESistema.Binario:
                    return new SistemaBinario(resultado.Valor);
                default:
                    return new SistemaDecimal(resultado.Valor); 
            }
        }

        public string ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder historial = new StringBuilder();
            historial.Append($"Sistema: {sistema}\n");
            historial.Append($"Primer Operando: {primerOperando.Valor}\n");
            historial.Append($"Segundo Operando: {segundoOperando.Valor}\n");
            historial.Append($"Operador: {operador}\n");

            return historial.ToString();
        }

        public void EliminarHistorialDeOperaciones()
        {
            operaciones.Clear();
        }
    }
}


