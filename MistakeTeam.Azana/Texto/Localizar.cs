using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace MistakeTeam.Azana.Texto
{
    ///<Summary>
    /// Localizar
    ///</Summary>
    public class Localizar
    {
        ///<Summary>
        /// Entra no resources de textos e retorna uma string com o valor da chave passada nos parâmetros.
        ///</Summary>
        public static string PegarTexto(string bloco, string chave)
        {
            string lang = "PT-BR";
            string pathEXE = Assembly.GetExecutingAssembly().Location.Replace("Azana.dll", "");
            string resourcePath = Path.GetFullPath(
                pathEXE + $"/resources/{lang}/{bloco}.resources"
            );

            //ConsoleLine.Enviar(resourcePath);
            ResourceReader rr = new(resourcePath);

            rr.GetResourceData(chave, out string dataType, out byte[] data);

            BinaryReader reader = new(new MemoryStream(data));
            string binData = reader.ReadString();

            rr.Close();
            return binData;
        }
    }
}
