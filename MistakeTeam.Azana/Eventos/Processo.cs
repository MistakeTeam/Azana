using MistakeTeam.Azana.Logs;

namespace MistakeTeam.Azana.Eventos
{
    public class Processo
    {
        internal static void OnProcessExit(object sender, EventArgs e)
        {
            LogFile.WriteLine("Tchauzinho");
        }
    }
}