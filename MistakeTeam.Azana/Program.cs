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
            LogFile.Iniciar(Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
            LogFile.WriteLine("Iniciando Azana...");

            // Iniciando modulos
            Eventos.Iniciar();
            Comandos.Iniciar();
            Mapa.Iniciar();

            // Mensagem de boas-vindas
            ConsoleLine.Enviar(ConsoleLine.FormatarLinha("Bem-vindo! ようこそ"));
            ConsoleLine.Enviar("Algo aconteceu...");
            ConsoleLine.Enviar(ConsoleLine.FormatarLinha());


            ConsoleLine.Enviar(Localizar.PegarTexto(TextoPath.NARRADOR, "oo"));

            Eventos.OnProcessExit((a, b) =>
            {
                LogFile.WriteLine("Tchauzinho");
            });

            // Loop de comandos
            bool ativo = true;
            while (ativo)
            {
                Console.Write(">");
                string iut = Console.ReadLine();

                Comandos.ExecutarComando(iut);
            }
        }

        public static async Task Main(string[] args)
        {
            try
            {
                await Task.Run(() =>
                {
                    Inicio();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
