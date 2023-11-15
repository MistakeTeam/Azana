using Remy.Logs;
using Remy.ScriptParse;
using YamlDotNet.RepresentationModel;

namespace Remy
{
    public static class Motor
    {
        private static string _nome;

        public static void Ligar(RemyOptions op)
        {
            _nome = op.Nome;

            LogFile.Iniciar(op.Nome);

            // Iniciando modulos
            Eventos.Iniciar();
            Comandos.Iniciar();

            Mensagem.BemVindo(op.BemVindo);

            ScriptsParse SP = new ScriptsParse($"{Directory.GetCurrentDirectory()}/Recursos/Script/Text.txt");
            Mensagem.Enviar(SP.GetChave("tommy.id"));
            Mensagem.Enviar(SP.GetChave("isso_pode.id"));
            Mensagem.Enviar(SP.GetChave("isso_pode.comer"));
            Mensagem.Enviar(SP.GetChave("isso_pode.correr"));
            Mensagem.Enviar(SP.GetChave("cade.comida"));
            Mensagem.Enviar(SP.GetChave("cade.mercado.arroz"));
            Mensagem.Enviar(SP.GetChave("cade.shopping.americanas.kitkat"));
            Mensagem.Enviar(SP.GetChave("cade.shopping.americanas.livros.fantasia.mistborn"));

            Eventos.OnProcessExit((a, b) =>
            {
                LogFile.WriteLine("[Remy] Desligando motor");
            });
        }
    }

    public class RemyOptions
    {
        public RemyOptions()
        {
            BemVindo = "Obrigrado pro jogar :)";
        }

        public string Nome { get; init; }
        public string BemVindo { get; init; }
    }
}