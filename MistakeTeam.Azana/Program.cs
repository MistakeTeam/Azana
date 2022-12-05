using System.Reflection;
using MistakeTeam.Azana.Ajudante;
using MistakeTeam.Azana.Comandos;
using MistakeTeam.Azana.Eventos;
using MistakeTeam.Azana.Logs;

namespace MistakeTeam.Azana
{
    public class Program
    {
        private static void Inicio()
        {
            LogFile.Iniciar();
            LogFile.WriteLine("Iniciando Azana...");

            // Iniciando modulos
            EventosMestre.Iniciar();
            ComandoMestre.Iniciar();

            // Mensagem de boas-vindas
            ConsoleLine.Enviar(ConsoleLine.FormatarLinha("Bem-vindo!"));
            ConsoleLine.Enviar("Algo aconteceu...");
            ConsoleLine.Enviar(ConsoleLine.FormatarLinha());

            // Loop de comandos
            bool ativo = true;
            while (ativo)
            {
                Console.Write(">");
                string iut = Console.ReadLine();

                ComandoMestre.ExecutarComando(iut);
            }
        }

        public static async Task Main(string[] args)
        {
            try
            {
                if (args.Length != 0)
                {
                    if (args[0] == "debug")
                    {
                        await Task.Run(() =>
                        {
                            //Process.Start(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Azana.exe");
                            Console.WriteLine(Assembly.GetEntryAssembly().Location);
                        });
                    }
                }

                await Task.Run(() =>
                {
                    Inicio();
                });
            }
            catch (Exception e)
            {
                await Task.Run(() =>
                {
                    Console.WriteLine(e);
                });
            }
        }
    }
}
