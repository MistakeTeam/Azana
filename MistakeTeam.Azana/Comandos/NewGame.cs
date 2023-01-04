using Remy;
using Remy.Interfaces;
using Remy.Logs;

namespace MistakeTeam.Azana
{
    public class NewGame : IComando
    {
        public string Nome => "newgame";
        public string Descricao => "Sem descrição";
        public string Aliase => "ng";

        public void Run()
        {
            foreach (string cn in Mundo.Mapa.PegarLista())
            {
                LogFile.WriteLine(cn);
                ConsoleLine.Enviar(cn);
            }
        }
    }
}
