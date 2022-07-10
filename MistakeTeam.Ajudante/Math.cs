using System;



namespace MistakeTeam.Azana.Ajudante
{
    ///<Summary>
    /// Classe calculadora, concentrando todas as funções matemáticas.
    ///</Summary>
    public class Calc
    {
        ///<Summary>
        /// Pegar a porcentagem de um valor.
        ///</Summary>
        public static float pegarporcentagem (float valor, float total) {
            return (valor/total)*100;
        }
    }
}