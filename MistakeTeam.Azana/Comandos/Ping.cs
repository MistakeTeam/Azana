namespace MistakeTeam.Azana.Comandos {
    public class Ping : IComando {
        public string Nome => "Ping";
        public string Descricao => "Sem descrição";
        
        public void Run () {
            Console.WriteLine("Pong!");
        }
    }
}