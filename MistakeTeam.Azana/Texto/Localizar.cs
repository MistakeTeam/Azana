using System;
using System.IO;
using System.Resources;
using System.Reflection;

//using MistakeTeam.Azana.Ajudante;

namespace MistakeTeam.Azana.Texto {
    ///<Summary>
    /// Localizar
    ///</Summary>
    public class Localizar {
        ///<Summary>
        /// Entra no resources de textos e retorna uma string com o valor da chave passada nos parâmetros.
        ///</Summary>
        public static string PegarTexto(string key) {
            var assembly = Assembly.GetExecutingAssembly();
            string pathEXE = Assembly.GetEntryAssembly().Location.Replace("/Azana.exe", "");
            string resourcePath = Path.GetFullPath(pathEXE + "/resources/PT-BR.resources");
            
            //ConsoleLine.Enviar(resourcePath);
            ResourceReader rr = new ResourceReader(resourcePath);

            string dataType = null;
            byte[] data = null;
            rr.GetResourceData(key, out dataType, out data);

            BinaryReader reader = new BinaryReader(new MemoryStream(data));
            string binData = reader.ReadString();

            rr.Close();
            return binData;
        }
    }
}