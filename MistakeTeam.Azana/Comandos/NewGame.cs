using Remy;

namespace MistakeTeam.Azana.Comando
{
    public class NewGame : ComandoAbstrado
    {
        public override string Nome => "newgame";
        public override string Descricao => "Sem descrição";
        public override string Aliase => "ng";

        public override void Run(string[] args)
        {
            // foreach (string cn in Mundo.Mapa.PegarLista())
            // {
            //     LogFile.WriteLine(cn);
            //     Mensagem.Enviar(cn);
            // }

            Mensagem.Enviar(IsSubComando());
            foreach (Type item in Filhos())
            {
                Mensagem.Enviar(item);
            }

            // ARGUMENTOS AAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            Mensagem.Enviar(args.Length);
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "easy":
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class EasyGame : ComandoAbstrado<NewGame>
    {
        public override string Nome => "easy";

        public override string Aliase => "opiu";

        public override string Descricao => "opiu";

        public override void Run(string[] args)
        {
            Mensagem.Enviar("[EasyGame] OI");
            Mensagem.Enviar(IsSubComando());
        }
    }
}
