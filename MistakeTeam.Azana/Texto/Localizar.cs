using Remy.Logs;

namespace MistakeTeam.Azana.Texto
{
    ///<Summary>
    /// Localizar
    ///</Summary>
    public class Localizar
    {
        ///<Summary>
        /// Entra no Bloco e retorna uma string com o valor da chave.
        ///</Summary>
        public static string PegarTexto(string bloco, string chave)
        {
            string[] txt = File.ReadAllLines(bloco);
            string s = "";

            for (int i = 0; i < txt.Length; i++)
            {
                string linha = txt[i];
                string[] tt = linha.Split("=");
                int numerolinha = i + 1;

                if (linha.StartsWith('#') || tt.Length <= 1)
                {
                    continue;
                }

                string c = tt[0].Replace("\"", "");
                string v = tt[1].Replace("\"", "");

                if (c == chave)
                {
                    s = v;
                }
                else
                {
                    s = c;
                }
            }

            return s;
        }

        public static string TextoAleatorio(string bloco)
        {
            string[] txt = File.ReadAllLines(bloco);
            string linha = txt[new Random().Next(txt.Length)];

            return linha.Replace("\"", "");
        }
    }
}
