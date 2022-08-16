using System;
using System.Resources;
using System.Reflection;

namespace MistakeTeam.Azana.Texto {
    ///<Summary>
    /// Localizar
    ///</Summary>
    public class Localizar {
        ///<Summary>
        /// Entra no resources de textos e retorna uma string com o valor da chave passada nos parâmetros.
        ///</Summary>
        public static string PegarTexto(string bloco, string chave) {
            string lang = "PT-BR";
            string pathEXE = Assembly.GetExecutingAssembly().Location.Replace("Azana.dll", "");
            string resourcePath = Path.GetFullPath(pathEXE + $"/resources/{lang}/{bloco}.resources");
            
            //ConsoleLine.Enviar(resourcePath);
            ResourceReader rr = new ResourceReader(resourcePath);

            string dataType = null;
            byte[] data = null;
            rr.GetResourceData(chave, out dataType, out data);

            BinaryReader reader = new BinaryReader(new MemoryStream(data));
            string binData = reader.ReadString();

            rr.Close();
            return binData;
        }
    }
}