namespace MistakeTeam.Azana.Texto
{
    public class TextoPath
    {
        private static Lang lang = Lang.PT_BR;
        private static string pathLANG = Directory.GetCurrentDirectory() + $"/Textos/{lang}/";

        // MAIN
        public static readonly string NARRADOR = $"{pathLANG}/Narrador.txt";
        public static readonly string NOMES_CIDADES = $"{pathLANG}/Nomes/Cidades.txt";
    }
}