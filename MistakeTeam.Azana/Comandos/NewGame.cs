using MistakeTeam.Azana.Ajudante;
using MistakeTeam.Azana.Interfaces;

namespace MistakeTeam.Azana.Comandos
{
    public class NewGame : IComando
    {
        public string Nome => "newgame";
        public string Descricao => "Sem descrição";
        public string Aliase => "ng";

        public void Run()
        {
            Jogador _jogador = new();

            ConsoleLine.Enviar(_jogador.Vida);
        }
    }
}
