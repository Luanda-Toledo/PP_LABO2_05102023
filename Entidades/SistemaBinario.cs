using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class SistemaBinario : Numeracion
    {
        public SistemaBinario(string valorInicial) : base(valorInicial)
        {
            this.valor = valorInicial;  
        }

        internal override double ValorNumerico
        {
            get
            {
                // Devuelve el valor de la nueva instancia en decimal
                SistemaDecimal sistemaDecimal = new SistemaDecimal(valor);
                return sistemaDecimal.ValorNumerico; 
            }
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema nuevoSistema)
        {
            if (nuevoSistema == ESistema.Decimal)
            {
                //conversión a decimal 
                int valorDecimal = (int)ValorNumerico;
                return new SistemaDecimal(valorDecimal.ToString());
            }
        }

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

        public SistemaDecimal BinarioADecimal()
        {
            if (EsSistemaBinarioValido(valor))
            {
                int valorDecimal = (int)ValorNumerico;
                return new SistemaDecimal(valorDecimal.ToString());
            }
        }

        // Conversión implícita de string a SistemaBinario
        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }
    }
}
