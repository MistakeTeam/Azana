using System.Reflection;
using MistakeTeam.Azana.Mundo;
using MistakeTeam.Azana.Texto;
using Remy;
using Remy.Logs;

namespace MistakeTeam.Azana
{
    public class Program
    {
        private static void Inicio()
        {
            Motor.Ligar(new RemyOptions()
            {
                Nome = "Azana",
                BemVindo = "Algo aconteceu..."
            }); // Partiu?

            // LogFile.Iniciar(Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
            LogFile.WriteLine("Iniciando Azana...");

            // Iniciando modulos
            Mapa.Iniciar();

            Mensagem.Enviar(Localizar.PegarTexto(TextoPath.NARRADOR, "oo"));

            Eventos.OnProcessExit((a, b) =>
            {
                LogFile.WriteLine("Tchauzinho");
            });

            // Loop de comandos
            while (true)
            {
                Console.Write(">");
                string[] args = Console.ReadLine().Split(" ");

                Comandos.Executar(args);
            }
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
