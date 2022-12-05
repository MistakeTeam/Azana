using MistakeTeam.Azana.Logs;

namespace MistakeTeam.Azana.Eventos
{
    public class EventosMestre
    {
        public static void Iniciar()
        {
            LogFile.WriteLine("Iniciando eventos...");

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Processo.OnProcessExit);
        }
    }
}