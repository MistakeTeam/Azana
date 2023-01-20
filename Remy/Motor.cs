using Remy.Logs;

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