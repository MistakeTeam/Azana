using Remy.Interfaces;

namespace MistakeTeam.Azana
{
    public class Ping : IComando
    {
        public string Nome => "ping";
        public string Descricao => "Sem descrição";
        public string Aliase => "";

        public void Run()
        {
            Console.WriteLine("Pong!");
        }
    }
}
