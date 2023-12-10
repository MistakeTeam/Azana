using Remy;
using Remy.Render;

namespace MistakeTeam.Azana.Comando
{
    public class Ping : ComandoAbstrado
    {
        public override string Nome => "ping";
        public override string Descricao => "Sem descrição";
        public override string Aliase => "";

        public override void Run(string[] args)
        {
            Console.WriteLine("Pong!");

            Mensagem.Enviar(IsSubComando());
            foreach (Type item in Filhos())
            {
                Mensagem.Enviar(item);
            }
        }
    }
}
