using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class SistemaDecimal : Numeracion
    {
        public SistemaDecimal(string valorInicial) : base(valorInicial)
        {
        }

        internal override double ValorNumerico
        {
            get
            {
                // Devuelve el valor de la nueva instancia en binario
                SistemaBinario sistemaDecimal = new SistemaBinario(valor);
                return sistemaDecimal.ValorNumerico;
            }
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema nuevoSistema)
        {
            if (nuevoSistema == ESistema.Binario)
            {
                // Implementa la lógica de conversión a binario aquí
                return new SistemaBinario(DecimalABinario());
            }
        }

        // Método para verificar si la cadena es una numeración válida en sistema decimal
        protected bool EsNumeracionValida(string valor)
        {
           if (EsSistemaDecimalValido(valor))
           {
                return true;
           }
   
            return false;
        }

        private bool EsSistemaDecimalValido(string valor)
        {
            double resultado;
            return double.TryParse(valor, out resultado);
        }

        private SistemaBinario DecimalABinario(int valorDecimal)
        {
            if (double.TryParse(valorDecimal, out double numeroDecimal))
            {
                // Verificar si el número es positivo y un entero
                if (numeroDecimal >= 0 && (int)numeroDecimal == numeroDecimal)
                {
                    // Tomar el valor entero
                    int numeroEntero = (int)numeroDecimal;

                    // Convertir a binario manualmente
                    string binario = string.Empty;
                    while (numeroEntero > 0)
                    {
                        binario = (numeroEntero % 2) + binario;
                        numeroEntero /= 2;
                    }
                    return binario;
                }
            }
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
