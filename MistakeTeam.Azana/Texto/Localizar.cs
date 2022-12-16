using System.IO;
using System.Resources;

namespace MistakeTeam.Azana.Texto
{
    ///<Summary>
    /// Localizar
    ///</Summary>
    public class Localizar
    {
        private string lang = "PT-BR";
        private string pathEXE = Directory.GetCurrentDirectory();

        ///<Summary>
        /// Entra no resources de textos e retorna uma string com o valor da chave passada nos parâmetros.
        ///</Summary>
        public string PegarTexto(string bloco, string chave)
        {
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
