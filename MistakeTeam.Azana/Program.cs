using MistakeTeam.Azana.Mundo;
using MistakeTeam.Azana.Texto;
using Remy;
using Remy.Logs;
using Remy.Render;
using Remy.Texto;

namespace MistakeTeam.Azana
{
    public class Program
    {
        public static Motor Remy = new Motor();

        public static void Inicio()
        {
            Remy.Ligar(new RemyOptions()
            {
                Nome = "Azana",
                BemVindo = "Algo aconteceu..."
            }); // Partiu?

            // LogFile.Iniciar(Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
            LogFile.WriteLine("Iniciando Azana...");

            // Iniciando modulos
            Mapa.Iniciar();

            Mensagem.Enviar(Localizar.PegarTexto(TextoPath.NARRADOR, "OO"));

            Eventos.OnProcessExit((a, b) =>
            {
                LogFile.WriteLine("Tchauzinho");
            });

            
        }

        public static async Task Main(string[] args)
        {
            try
            {
                await Task.Run(Inicio);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
