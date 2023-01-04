using System;

namespace Remy
{
    ///<Summary>
    /// Classe calculadora, concentrando todas as funções matemáticas.
    ///</Summary>
    public class Calc
    {
        ///<Summary>
        /// Pegar a porcentagem de um valor.
        ///</Summary>
        public static float Pegarporcentagem(float valor, float total)
        {
            return (valor / total) * 100;
        }
    }
}
